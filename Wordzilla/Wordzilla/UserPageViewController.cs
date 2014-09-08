using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Wordzilla
{
	partial class UserPageViewController : UIViewController
	{
		public UserPageViewController (IntPtr handle) : base (handle)
		{
		}

		private int _sheetId;
		private TableSource _dsmysheets;
		private TableSource _dsteachersheets;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//ConfigureProccess ();

			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem () { Title = "Обновить" }, true);
			NavigationItem.RightBarButtonItem.Clicked += (s, e) => {
				UpdateData ();
			};

			// init data
			StudentManagment.Words.Areas.api.Models.Sheet.TableModel userData = AppApi.GetSheets ();

			var teachertable = userData.DataTeacher;
			UITeacherCards.Source = _dsteachersheets = new TableSource (teachertable, this);
			UITeacherCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);

			var mytable = userData.DataStudent;
			UIMyCards.Source = _dsmysheets = new TableSource (mytable, this);
			UIMyCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);
		}

		private void UpdateData ()
		{
			// update data
			StudentManagment.Words.Areas.api.Models.Sheet.TableModel userData = null;//AppApi.GetSheets ();

			Task.Factory.StartNew (
				() => {
					userData = AppApi.GetSheets ();
				}
			).ContinueWith (
				t => {
					_dsteachersheets.Objects.Clear ();
					_dsmysheets.Objects.Clear ();

					foreach (var e in userData.DataStudent) {
						_dsmysheets.Objects.Add (e);
					}
					foreach (var e in userData.DataTeacher) {
						_dsteachersheets.Objects.Add (e);
					}

					UITeacherCards.ReloadData ();
					UIMyCards.ReloadData ();
				}, TaskScheduler.FromCurrentSynchronizationContext ()
			);

		}

		private void Edit (int selectedSheet)
		{
			// for editing
			_sheetId = selectedSheet;
			PerformSegue ("EditSheet", this);
		}

		private void Training (int selectedSheet)
		{
			_sheetId = selectedSheet;
			PerformSegue ("TrainingPage", this);
		}

		public void ConfigureData (int pState)
		{

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			switch (segue.Identifier) {
			case "TrainingPage":
				((TrainingViewController)segue.DestinationViewController).ConfigureView (_sheetId);
				break;
			case "EditSheet":
				((EditWordsController)segue.DestinationViewController).ConfigureView (_sheetId);
				break;
			}
		}

		public class TableSource : UITableViewSource
		{
			List<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> tableItems;
			UserPageViewController controller;

			public IList<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> Objects {
				get { return tableItems; }
			}

			public TableSource (List<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> items, UserPageViewController controller)
			{
				tableItems = items;
				this.controller = controller;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return tableItems.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = UIListWordCell.Create ();//tableView.DequeueReusableCell (UIListWordCell.Key, indexPath) as UIListWordCell;
				// if there are no cells to reuse, create a new one
				//if (cell == null)
				//	cell = new UIListWordCell (UITableViewCellStyle.Default, cellIdentifier);

				var oneItem = tableItems [indexPath.Row];
				cell.Id = oneItem.Id;
				cell.Title = oneItem.Name;
				cell.Info = oneItem.Type + " " + oneItem.DateCreate + " " + (oneItem.IsNew != null ? "new" : "");
				cell.EditBtmEvent = (object sender, EventArgs e) => {
					((UserPageViewController)controller).Edit (tableItems [indexPath.Row].Id);
				};
				cell.TrainingBtmEvent = (object sender, EventArgs e) => {
					((UserPageViewController)controller).Training (tableItems [indexPath.Row].Id);
				};



				//Customizing the progress bar
				float sumWordAnswers = oneItem.Bad + oneItem.Good + oneItem.Nearly + oneItem.No;
				var width = cell.ProgressBarPlace.Width;
				var height = cell.ProgressBarPlace.Height;

				if (sumWordAnswers != 0) {

					var badWidth = (oneItem.Bad / sumWordAnswers) * width;
					var goodWidth = (oneItem.Good / sumWordAnswers) * width;
					var noWidth = (oneItem.No / sumWordAnswers) * width;
					var nearlyWidth = (oneItem.Nearly / sumWordAnswers) * width;

					cell.ProgressBarRed = new System.Drawing.RectangleF (0, 0, badWidth, height);
					cell.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 0, nearlyWidth, height);
					cell.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + nearlyWidth, 0, goodWidth, height);
					cell.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + nearlyWidth + goodWidth, 0, noWidth, height);
				} else {
					cell.ProgressBarRed = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarGreen = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarYellow = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarSilver = new System.Drawing.RectangleF (0, 0, width, height);
				}
				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				//new UIAlertView("Row Selected", tableItems[indexPath.Row], null, "OK", null).Show();
				//controller.selectedId =tableItems [indexPath.Row].Id;
				//controller.PerformSegue ("TrainingPage", controller);

				tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
			}
		}
	}
}

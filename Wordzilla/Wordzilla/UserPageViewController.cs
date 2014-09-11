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

		private StudentManagment.Words.Areas.api.Models.Sheet.MiniModel _selSheet;
		private TableSource _dsmysheets;
		private TableSource _dsteachersheets;
		private long _groupId;
		private int _selectMode=1;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//ConfigureProccess ();

			/*NavigationItem.SetRightBarButtonItem (new UIBarButtonItem () { Title = "Обновить" }, true);
			NavigationItem.RightBarButtonItem.Clicked += (s, e) => {
				UpdateData ();
			};*/

			// init data
		}

		public override void ViewWillAppear (bool animation)
		{
			base.ViewWillAppear (animation);
			UpdateData ();
		}

		private void UpdateData ()
		{
			// update data
			StudentManagment.Words.Areas.api.Models.Sheet.TableModel userData = null;
			if (_dsteachersheets == null || _dsmysheets == null) {
				userData = AppApi.GetSheets ();

				var teachertable = userData.DataTeacher;
				UITeacherCards.Source = _dsteachersheets = new TableSource (teachertable, 2, this);
				UITeacherCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);

				var mytable = userData.DataStudent;
				UIMyCards.Source = _dsmysheets = new TableSource (mytable, 1, this);
				UIMyCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);

				_groupId = userData.GroupId;
				return;
			}

			//AppApi.GetSheets ();

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

		private void Edit (StudentManagment.Words.Areas.api.Models.Sheet.MiniModel selectedSheet)
		{
			// for editing
			_selSheet = selectedSheet;
			PerformSegue ("EditSheet", this);
		}

		private void Training (StudentManagment.Words.Areas.api.Models.Sheet.MiniModel selectedSheet)
		{
			_selSheet = selectedSheet;
			PerformSegue ("TrainingPage", this);
		}

		public void ConfigureData (int pState)
		{

		}

		partial void AddNewWordsVerbs (UIButton sender)
		{
			if (sender.Tag == 1)
				_selSheet = new StudentManagment.Words.Areas.api.Models.Sheet.MiniModel ()
			{ Type = "Слова" };
			else
				_selSheet = new StudentManagment.Words.Areas.api.Models.Sheet.MiniModel ()
			{ Type = "Глаголы" };

			PerformSegue ("EditSheet", this);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			switch (segue.Identifier) {
			case "TrainingPage":
				((TrainingViewController)segue.DestinationViewController).ConfigureView (_selSheet);
				break;
			case "EditSheet":
				((EditWordsController)segue.DestinationViewController).ConfigureView (_groupId, _selSheet,_selectMode);
				break;
			}
		}

		public class TableSource : UITableViewSource
		{
			List<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> tableItems;
			UserPageViewController controller;
			int mode;

			public IList<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> Objects {
				get { return tableItems; }
			}

			public TableSource (List<StudentManagment.Words.Areas.api.Models.Sheet.MiniModel> items, int mode, UserPageViewController controller)
			{
				tableItems = items;
				this.controller = controller;
				this.mode = mode;
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
					controller._selectMode=1;
					controller.Edit (tableItems [indexPath.Row]);
				};
				cell.TrainingBtmEvent = (object sender, EventArgs e) => {
					controller.Training (tableItems [indexPath.Row]);
				};

				cell.DeleteBtmEvent = (object sender, EventArgs e) => {
					try {
						if (!AppApi.DeleteSheet (tableItems [indexPath.Row].Id))
							return;
						tableItems.RemoveAt (indexPath.Row);
						tableView.DeleteRows (new NSIndexPath[]{ indexPath }, UITableViewRowAnimation.Fade);
					} catch {
					}
				};

				cell.ListOfWordsBtmEvent = (object sender, EventArgs e) => {
					controller._selectMode=2;
					controller.Edit (tableItems [indexPath.Row]);
				};

				//Customizing the progress bar
				float sumWordAnswers = oneItem.Bad + oneItem.Good + oneItem.Nearly + oneItem.No;
				var customProgressBar = UICustomProgressBar.Create ();
				customProgressBar.Frame = new System.Drawing.RectangleF (3, 40, 160, 4);
				//var width = cell.ProgressBarPlace.Width;
				//var height = cell.ProgressBarPlace.Height;
				var width = customProgressBar.Frame.Width;
				var height = customProgressBar.Frame.Height;

				if (sumWordAnswers != 0) {

					var badWidth = (oneItem.Bad / sumWordAnswers) * width;
					var goodWidth = (oneItem.Good / sumWordAnswers) * width;
					var noWidth = (oneItem.No / sumWordAnswers) * width;
					var nearlyWidth = (oneItem.Nearly / sumWordAnswers) * width;

					/*	cell.ProgressBarRed = new System.Drawing.RectangleF (0, 0, badWidth, height);
					cell.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 0, nearlyWidth, height);
					cell.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + nearlyWidth, 0, goodWidth, height);
					cell.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + nearlyWidth + goodWidth, 0, noWidth, height);*/
					customProgressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 2, badWidth, height);
					customProgressBar.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 2, nearlyWidth, height);
					customProgressBar.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + nearlyWidth, 2, goodWidth, height);
					customProgressBar.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + nearlyWidth + goodWidth, 2, noWidth, height);

				} else {
					/*cell.ProgressBarRed = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarGreen = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarYellow = new System.Drawing.RectangleF (0, 0, 0, 0);
					cell.ProgressBarSilver = new System.Drawing.RectangleF (0, 0, width, height);*/

					customProgressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 0, 0, 0);
					customProgressBar.ProgressBarYellow = new System.Drawing.RectangleF (0, 0, 0, 0);
					customProgressBar.ProgressBarGreen = new System.Drawing.RectangleF (0, 0, 0, 0);
					customProgressBar.ProgressBarSilver = new System.Drawing.RectangleF (0, 0, width, height);


					// hide buttons if list does not contain words
					cell.ListOfWordsButtonHidden = true;
					cell.TraininButtonHidden = true;
				}

				if (mode == 2)
					cell.TeacherEditButtonsHidden = true;

				cell.AddSubview (customProgressBar);
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

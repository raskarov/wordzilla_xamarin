using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	partial class UserPageViewController : UIViewController
	{
		public UserPageViewController (IntPtr handle) : base (handle)
		{
		}

		private int _sheetId;

		public override void ViewWillAppear (bool animation)
		{
			base.ViewWillAppear (animation);
			var userData = AppApi.GetSheets ();

			StudentManagment.Words.Areas.api.Models.Sheet.MiniModel[] teachertable = userData.DataTeacher.ToArray();
			UITeacherCards.Source = new TableSource(teachertable,this);
			UITeacherCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);

			StudentManagment.Words.Areas.api.Models.Sheet.MiniModel[] mytable = userData.DataStudent.ToArray();
			UIMyCards.Source = new TableSource(mytable,this);
			UIMyCards.RegisterNibForCellReuse (UIListWordCell.Nib, UIListWordCell.Key);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//ConfigureProccess ();


		}

		/*private void ConfigureProccess(){
			var width = UICustomProccessBar.Frame.Width;

			var red = width * 2 / 100;
			var green = width * 1 / 100;
			var yellow = width * 2 / 100;

			var sum = width/red + width/green + width/yellow;
		}*/

		private void Edit(int selectedSheet){
			// for editing
			_sheetId = selectedSheet;
			PerformSegue ("EditSheet", this);
		}

		private void Training(int selectedSheet){
			_sheetId = selectedSheet;
			PerformSegue ("TrainingPage", this);
		}

		public void ConfigureData(int pState){

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

		public class TableSource : UITableViewSource {
			StudentManagment.Words.Areas.api.Models.Sheet.MiniModel[] tableItems;
			UserPageViewController controller;

			public TableSource (StudentManagment.Words.Areas.api.Models.Sheet.MiniModel[] items,UserPageViewController controller) 
			{
				tableItems = items;
				this.controller=controller;
			}
			public override int RowsInSection (UITableView tableview, int section)
			{
				return tableItems.Length;
			}
			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (UIListWordCell.Key, indexPath) as UIListWordCell;
				// if there are no cells to reuse, create a new one
				//if (cell == null)
				//	cell = new UIListWordCell (UITableViewCellStyle.Default, cellIdentifier);

				var oneItem = tableItems [indexPath.Row];
				cell.Id = oneItem.Id;
				cell.Title = oneItem.Name;
				cell.Info = oneItem.Type + " " + oneItem.DateCreate + " " + (oneItem.IsNew != null ? "new" : "");
				cell.EditBtmEvent= (object sender, EventArgs e) => {
					((UserPageViewController)controller).Edit(tableItems [indexPath.Row].Id);
				};
				cell.TrainingBtmEvent= (object sender, EventArgs e) => {
					((UserPageViewController)controller).Training(tableItems [indexPath.Row].Id);
				};



				//Customizing the progress bar
				float sumWordAnswers = oneItem.Bad + oneItem.Good + oneItem.Nearly + oneItem.No;
				var width = cell.ProgressBarPlace.Width;
				var height = cell.ProgressBarPlace.Height;

				if (sumWordAnswers != 0) {

					var badWidth = (oneItem.Bad / sumWordAnswers) * width;
					var goodWidth = (oneItem.Good / sumWordAnswers) * width;
					var nearlyWidth = (oneItem.Nearly / sumWordAnswers) * width;
					var noWidth = (oneItem.No / sumWordAnswers) * width;

					cell.ProgressBarRed = new System.Drawing.RectangleF (0, 0, badWidth, height);
					cell.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 0, noWidth, height);
					cell.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + noWidth, 0, goodWidth, height);
					cell.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + noWidth + goodWidth, 0, nearlyWidth, height);
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

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace Wordzilla
{
	partial class EditWordsController : UITableViewController
	{
		//DataSource dataSource;

		public EditWordsController (IntPtr handle) : base (handle)
		{
		}

		private StudentManagment.Words.Areas.api.Models.Words.MiniModel _selectWord;
		private StudentManagment.Words.Areas.api.Models.Sheet.MiniModel _selectSheet;
		private int _controllerMode;
		private long _groupId;

		public override void ViewWillAppear (bool animation)
		{
			base.ViewWillAppear (animation);

			StudentManagment.Words.Areas.api.Models.Sheet.EditModel editModel;
			StudentManagment.Words.Areas.api.Models.Words.TableModel userData;

			// if selectsheet!=null this is exist sheet
			if (_selectSheet.Id != 0) {
				userData = AppApi.GetDataTable (_selectSheet.Id);
				editModel = AppApi.GetEdit (userData.SheetWordId, userData.GroupId, _selectSheet.Type.ToLower () == "слова" ? 1 : 2);

			} else {
				// create new sheet
				editModel = AppApi.GetEdit (0, _groupId, _selectSheet.Type.ToLower () == "слова" ? 1 : 2);
				userData = new StudentManagment.Words.Areas.api.Models.Words.TableModel ();
				userData.GroupId = 0;
				userData.SheetWordId = editModel.SheetId;

				_selectSheet.Id = editModel.SheetId;
			}

			TableView.Source = new TableSource (userData, editModel, this);
			TableView.RegisterNibForCellReuse (UIWordEdit.Nib, UIListWordCell.Key);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem () { Title = "Добавить" }, true);
			NavigationItem.RightBarButtonItem.Clicked += (s, e) => {
				_selectWord = null;
				PerformSegue ("EditWord", this);
			};
		}

		public void ConfigureView (long groupId, StudentManagment.Words.Areas.api.Models.Sheet.MiniModel sheet = null, int mode = 1)
		{
			// mode -1 (edit) mode -2 (list)
			//	if (sheet != null) {
			_selectSheet = sheet;
			_controllerMode = mode;
			_groupId = groupId;
			//		return;
			//	}
		}

		// edit selected word
		void Edit (StudentManagment.Words.Areas.api.Models.Words.MiniModel word)
		{
			_selectWord = word;
			PerformSegue ("EditWord", this);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EditWord") // if _selectword this is new word
				((EditWordViewController)segue.DestinationViewController).ConfigureView (_selectSheet.Id, _selectWord);

		}

		public class TableSource : UITableViewSource
		{
			StudentManagment.Words.Areas.api.Models.Words.TableModel model;
			StudentManagment.Words.Areas.api.Models.Sheet.EditModel editModel;
			EditWordsController controller;

			public TableSource (StudentManagment.Words.Areas.api.Models.Words.TableModel model, StudentManagment.Words.Areas.api.Models.Sheet.EditModel editmodel, EditWordsController controller)
			{
				this.model = model;
				this.controller = controller;
				this.editModel = editmodel;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				if (section == 0)
					return 1;
				return model.Data == null ? 0 : model.Data.Count;
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return 2;
			}

			public override string TitleForHeader (UITableView tableView, int section)
			{
				if (section == 0) {
					if (editModel != null)
						return editModel.DateCreate;
				}
				return "Слова";
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				if (indexPath.Section == 0) {
					var infocell = new UITableViewCell ();
					if (controller._controllerMode == 2) {
						var inform = AppApi.GetSheets ().DataStudent.First (x => x.Id == editModel.SheetId);
						//Customizing the progress bar
						float sumWordAnswers = inform.Bad + inform.Good + inform.Nearly + inform.No;
						var customProgressBar = UICustomProgressBar.Create ();
						customProgressBar.Frame = new System.Drawing.RectangleF (10, 40, UIScreen.MainScreen.Bounds.Width-20, 4);
						var width = customProgressBar.Frame.Width;
						var height = customProgressBar.Frame.Height;

						if (sumWordAnswers != 0) {

							var badWidth = (inform.Bad / sumWordAnswers) * width;
							var goodWidth = (inform.Good / sumWordAnswers) * width;
							var noWidth = (inform.No / sumWordAnswers) * width;
							var nearlyWidth = (inform.Nearly / sumWordAnswers) * width;

							customProgressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 2, badWidth, height);
							customProgressBar.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 2, nearlyWidth, height);
							customProgressBar.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + nearlyWidth, 2, goodWidth, height);
							customProgressBar.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + nearlyWidth + goodWidth, 2, noWidth, height);

						} else {
							customProgressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 0, 0, 0);
							customProgressBar.ProgressBarYellow = new System.Drawing.RectangleF (0, 0, 0, 0);
							customProgressBar.ProgressBarGreen = new System.Drawing.RectangleF (0, 0, 0, 0);
							customProgressBar.ProgressBarSilver = new System.Drawing.RectangleF (0, 0, width, height);
						}
						infocell.AddSubview (customProgressBar);
					} else {
						UITextField title = new UITextField (new System.Drawing.RectangleF (15, 35, UIScreen.MainScreen.Bounds.Width - 130, 20));
						title.Placeholder = "Введите название";
						title.BorderStyle = UITextBorderStyle.RoundedRect;
						if (editModel != null)
							title.Text = editModel.Name;

						UIButton save = new UIButton (new System.Drawing.RectangleF (title.Frame.Right + 5, 35, 100, 20));
						save.SetTitle ("Сохранить", UIControlState.Normal);
						save.BackgroundColor = UIColor.FromRGB (15, 83, 250);

						save.TouchUpInside += (object sender, EventArgs e) => {

						};

						infocell.AddSubviews (new UIView[]{ title, save });
					}


					return infocell;
				}

				var cell = UIWordEdit.Create (); //tableView.DequeueReusableCell (UIWordEdit.Key, indexPath) as UIWordEdit;
				// if there are no cells to reuse, create a new one
				//if (cell == null)
				//	cell = new UIListWordCell (UITableViewCellStyle.Default, cellIdentifier);

				var oneItem = model.Data [indexPath.Row];
				cell.Id = oneItem.Id;
				cell.Russian = oneItem.Russian;
				cell.Transcr = oneItem.Transcription;
				cell.Example = oneItem.Description;
				cell.English = oneItem.English;
				cell.EditBtmEvent = (object sender, EventArgs e) => {
					controller.Edit (model.Data [indexPath.Row]);
				};
				cell.DelBtmEvent = (object sender, EventArgs e) => {
					if (!AppApi.DeleteWord (model.Data [indexPath.Row].Id))
						return;
					model.Data.RemoveAt (indexPath.Row);
					tableView.DeleteRows (new NSIndexPath[]{ indexPath }, UITableViewRowAnimation.Fade);
				};

				if (controller._controllerMode == 2)
					cell.DisableControls = true;

				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
			}
		}
	}
}

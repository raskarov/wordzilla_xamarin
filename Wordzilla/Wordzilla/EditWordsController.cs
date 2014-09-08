using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Wordzilla
{
	partial class EditWordsController : UITableViewController
	{
		//DataSource dataSource;

		public EditWordsController (IntPtr handle) : base (handle)
		{
		}

		private StudentManagment.Words.Areas.api.Models.Words.MiniModel _selectWord;
		private int _sheetId;

		public override void ViewWillAppear (bool animation)
		{
			base.ViewWillAppear (animation);

			var userData = AppApi.GetDataTable (_sheetId).Data;

			var teachertable = userData;
			TableView.Source = new TableSource(teachertable,this);
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

		public void ConfigureView(int sheetid){
			_sheetId = sheetid;
		}

		// edit selected word
		void Edit(StudentManagment.Words.Areas.api.Models.Words.MiniModel word){
			_selectWord = word;
			PerformSegue ("EditWord", this);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EditWord") // if _selectword this is new word
				((EditWordViewController)segue.DestinationViewController).ConfigureView (_sheetId,_selectWord);

		}

		public class TableSource : UITableViewSource {
			List<StudentManagment.Words.Areas.api.Models.Words.MiniModel> tableItems;
			EditWordsController controller;

			public TableSource (List<StudentManagment.Words.Areas.api.Models.Words.MiniModel> items,EditWordsController controller) 
			{
				tableItems = items;
				this.controller=controller;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return tableItems.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = UIWordEdit.Create (); //tableView.DequeueReusableCell (UIWordEdit.Key, indexPath) as UIWordEdit;
				// if there are no cells to reuse, create a new one
				//if (cell == null)
				//	cell = new UIListWordCell (UITableViewCellStyle.Default, cellIdentifier);

				var oneItem = tableItems [indexPath.Row];
				cell.Id = oneItem.Id;
				cell.Russian = oneItem.Russian;
				cell.Transcr = oneItem.Transcription;
				cell.Example = oneItem.Description;
				cell.English = oneItem.English;
				cell.EditBtmEvent= (object sender, EventArgs e) => {
					((EditWordsController)controller).Edit(tableItems [indexPath.Row]);
				};
				cell.DelBtmEvent= (object sender, EventArgs e) => {
					if(!AppApi.DeleteWord(tableItems [indexPath.Row].Id))return;
					tableItems.RemoveAt(indexPath.Row);
					tableView.DeleteRows(new NSIndexPath[]{indexPath},UITableViewRowAnimation.Fade);
				};

				return cell;
			}
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
			}
		}
	}
}

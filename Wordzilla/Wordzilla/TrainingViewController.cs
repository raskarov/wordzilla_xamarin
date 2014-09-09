using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	partial class TrainingViewController : UIViewController
	{
		public TrainingViewController (IntPtr handle) : base (handle)
		{
		}

		// index of card
		int index=0;

		StudentManagment.Words.Areas.api.Models.Words.MiniModel[] data;
		private StudentManagment.Words.Areas.api.Models.Sheet.MiniModel _sheet;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ShowData ();
		}

		//Download information cards
		void ShowData(){
			UIWord.Text = data [index].English;
			UITranslate.Text = data [index].Transcription;
			UIRussian.Text = data [index].Russian;
		}

		public void ConfigureView (StudentManagment.Words.Areas.api.Models.Sheet.MiniModel sheet)
		{
			_sheet = sheet;
			data = AppApi.GetSequenceExternal (sheet.Id).Data.ToArray ();
		}

		partial void AnswerTouch (UIButton sender)
		{
			UIAnswerPlace.Hidden = false;
		}

		partial void SelectAnswerTouch (UIButton sender)
		{
			var answer = string.Empty;
			switch (sender.Tag) {
			case 1:
				answer="Yes";
				break;
			case 2:
				answer="Nearly";
				break;
			case 3:
				answer="No";
				break;
			}

			AppApi.SetLearnWordExternal(_sheet.Id,data[index].WordId,answer);

			index++;

			//If limit is the repeat loop boot
			if(index>=data.Length){
				index=0;
				data = AppApi.GetSequenceExternal (_sheet.Id).Data.ToArray ();
			}

			ShowData();

			UIAnswerPlace.Hidden = true;
		}
	}
}

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	partial class EditWordViewController : UIViewController
	{
		public EditWordViewController (IntPtr handle) : base (handle)
		{

		}

		private StudentManagment.Words.Areas.api.Models.Words.MiniModel _word;
		private int _sheetWordId;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (_word == null)
				return;

			UIEnglish.Text = _word.English;
			UIRussian.Text = _word.Russian;
			UIExample.Text = _word.Description;
			UITranscription.Text = _word.Transcription;
		}

		public override void ViewDidDisappear (bool animation)
		{
			base.ViewDidDisappear (animation);
			AppApi.UpdateField(_word.Id,"Russian",UIRussian.Text,_sheetWordId);
			AppApi.UpdateField(_word.Id,"Transcription",UITranscription.Text,_sheetWordId);
			AppApi.UpdateField(_word.Id,"Description",UIExample.Text,_sheetWordId);
		}

		public void ConfigureView (int sheetWordId, StudentManagment.Words.Areas.api.Models.Words.MiniModel word=null)
		{
			// configure view / populate data
			_word = word;
			_sheetWordId = sheetWordId;
		}

		partial void EndEditing (UITextField sender){
			//a temporary solution until the desired function is not api
			if(sender.Tag==1){
				var data = AppApi.UpdateField(_word==null?0:_word.Id,"English",UIEnglish.Text,_sheetWordId);
				UIRussian.Text=data["RussianValue"].ToString();
				UITranscription.Text=data["TranscriptionValue"].ToString();
				UIExample.Text=data["Description"].ToString();

				//create wordData
				_word=new StudentManagment.Words.Areas.api.Models.Words.MiniModel();
				_word.Id=int.Parse(data["Id"].ToString());
				_word.Russian=UIRussian.Text;
				_word.Transcription=UITranscription.Text;
				_word.Description=UIExample.Text;
			}
			//	AppApi.UpdateField(_word.Id,"Russian",UIRussian.Text,_sheetWordId);
			//	AppApi.UpdateField(_word.Id,"Transcription",UITranscription.Text,_sheetWordId);
			//	AppApi.UpdateField(_word.Id,"Description",UIExample.Text,_sheetWordId);
		}
	}
}

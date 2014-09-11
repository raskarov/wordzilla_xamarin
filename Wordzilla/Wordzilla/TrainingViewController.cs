using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;

namespace Wordzilla
{
	partial class TrainingViewController : UIViewController
	{
		public TrainingViewController (IntPtr handle) : base (handle)
		{
		}

		// index of card
		int index = 0;

		//private StudentManagment.Words.Areas.api.Models.Flashcard.CardUpModel[] data;
		private StudentManagment.Words.Areas.api.Models.Sheet.MiniModel _sheet;
		private UICustomProgressBar progressBar = UICustomProgressBar.Create();
		private UIOneCard[] _words;

		private bool nowSpeaking = false;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			progressBar.Frame = new System.Drawing.RectangleF (40, 30, View.Frame.Width - 80, 7);
			View.AddSubview (progressBar);
			UpdateProgressbar ();

			UICardPlace.AddSubviews (_words);
			UICardPlace.ContentSize = new System.Drawing.SizeF (_words [_words.Length - 1].Right+20, 0);

			UICardPlace.DraggingEnded += EndAnimationScroll;
		//	UICardPlace.ScrollAnimationEnded += EndAnimationScroll;
			UICardPlace.Scrolled += Scrolled;
		}

		void EndAnimationScroll (object sender, EventArgs e)
		{
			GetCenteredBlock ();
		}

		void Scrolled (object sender, EventArgs args)
		{
			if (UICardPlace.Decelerating)
				GetCenteredBlock ();

			var proposedContentOffset = UICardPlace.ContentOffset;
			float horizontalCenter = (float)(proposedContentOffset.X + (UICardPlace.Bounds.Size.Width / 2.0));

			RectangleF pointer = new RectangleF (horizontalCenter, 10, 10, 10);
			var matched = _words.FirstOrDefault(x=>pointer.IntersectsWith (x.Frame));
			if (matched!=null) {
				switch (matched.Status) {
				case 3:
					View.BackgroundColor = UIColor.Red;
					break;
				case 1:
					View.BackgroundColor = UIColor.Green;
					break;
				case 2:
					View.BackgroundColor = UIColor.Yellow;
					break;
				default:
					View.BackgroundColor = UIColor.Gray;
					break;
				}
			}
		}

		void GetCenteredBlock ()
		{
			//if (UICardPlace.Decelerating)
			//	return;

			var proposedContentOffset = UICardPlace.ContentOffset;
			float horizontalCenter = (float)(proposedContentOffset.X + (UICardPlace.Bounds.Size.Width / 2.0));

			RectangleF pointer = new RectangleF (horizontalCenter, 10, 10, 10);

			for (int i = 0; i < _words.Length; i++) {
					if (pointer.IntersectsWith (_words [i].Frame)) {
						ForceCenter (i);
						break;
					}
			}
		}

		void ForceCenter(int i){
			var proposedContentOffset = UICardPlace.ContentOffset;
			float offSetAdjustmentX = float.MaxValue;
			float horizontalCenter = (float)(proposedContentOffset.X + (UICardPlace.Bounds.Size.Width / 2.0));

			offSetAdjustmentX = _words[i].Center.X - horizontalCenter;

			index = i;

			UICardPlace.SetContentOffset (new PointF (proposedContentOffset.X + offSetAdjustmentX, 
				proposedContentOffset.Y), true); 
		}

		//Download information cards
		void ShowData ()
		{
			UIAnswerPlace.Hidden = true;
			UICardPlace.Hidden = false;

			switch (_words [index].Status) {
			case 3:
				View.BackgroundColor = UIColor.Red;
				break;
			case 1:
				View.BackgroundColor = UIColor.Green;
				break;
			case 2:
				View.BackgroundColor = UIColor.Yellow;
				break;
			default:
				View.BackgroundColor = UIColor.Gray;
				break;
			}

			UpdateProgressbar ();
		}

		private void UpdateProgressbar(){

			//Customizing the progress bar
			float sumWordAnswers = _words.Length;
			var width = progressBar.Frame.Width;
			var height = progressBar.Frame.Height;

			var items = new int[4];
			foreach (var oneItem in _words) {
				items[oneItem.Status]++;
			}

			if (sumWordAnswers != 0) {
				var badWidth = (items[3] / sumWordAnswers) * width;
				var goodWidth = (items[1] / sumWordAnswers) * width;
				var noWidth = (items[2] / sumWordAnswers) * width;
				var nearlyWidth = (items[0] / sumWordAnswers) * width;

				progressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 2, badWidth, height);
				progressBar.ProgressBarYellow = new System.Drawing.RectangleF (badWidth, 2, nearlyWidth, height);
				progressBar.ProgressBarGreen = new System.Drawing.RectangleF (badWidth + nearlyWidth, 2, goodWidth, height);
				progressBar.ProgressBarSilver = new System.Drawing.RectangleF (badWidth + nearlyWidth + goodWidth, 2, noWidth, height);

			} else {
				progressBar.ProgressBarRed = new System.Drawing.RectangleF (0, 0, 0, 0);
				progressBar.ProgressBarYellow = new System.Drawing.RectangleF (0, 0, 0, 0);
				progressBar.ProgressBarGreen = new System.Drawing.RectangleF (0, 0, 0, 0);
				progressBar.ProgressBarSilver = new System.Drawing.RectangleF (0, 0, width, height);
			}

		}

		public void ConfigureView (StudentManagment.Words.Areas.api.Models.Sheet.MiniModel sheet)
		{
			_sheet = sheet;
			ComposeData (_sheet.Id);
		}

		//data shaping
		private void ComposeData(int id){
			var data = AppApi.GetSequenceExternal (id).Data.ToArray ();
			_words = new UIOneCard[data.Length];
			for(int i =0 ;i< data.Length;i++)
			{
				if (_words [i] != null) {
					_words [i].RemoveFromSuperview ();
					_words [i] = null;
				}

				var dataItem = data [i];

				float leftOffset = 10;
				if (i != 0)
					leftOffset += _words[i-1].Right;

				_words [i] = UIOneCard.Create (dataItem.WordId, dataItem.English, dataItem.Transcription, 
					dataItem.Description, dataItem.Status,dataItem.Russian,leftOffset);

				_words [i].TouchAnswer = (object sender, EventArgs e) => {
					UIAnswerPlace.Hidden = false;
					UICardPlace.Hidden = true;
				};

			}
		}
		/*
		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);
			if (nowSpeaking)
				return; // if event started

			UITouch touch = touches.AnyObject as UITouch;
			if (touch != null)
			if (touch.TapCount == 1) {
				UIAnswerPlace.Hidden = false;
				UICardPlace.Hidden = true;
			}
		}*/

		partial void SelectAnswerTouch (UIButton sender)
		{
			var answer = string.Empty;
			switch (sender.Tag) {
			case 1:
				answer = "Yes";
				_words[index].Status=1;
				break;
			case 2:
				answer = "Nearly";
				_words[index].Status=2;
				break;
			case 3:
				answer = "No";
				_words[index].Status=3;
				break;
			}

			AppApi.SetLearnWordExternal (_sheet.Id, _words [index].WordId, answer);

			index++;

			//If limit is the repeat loop boot
			if (index >= _words.Length) {
				index=0;
				ComposeData(_sheet.Id);
				UICardPlace.AddSubviews (_words);
				UICardPlace.ContentSize = new System.Drawing.SizeF (_words [_words.Length - 1].Right + _words [0].Frame.Width, UICardPlace.Frame.Height);
			}

			ForceCenter(index);

			ShowData ();
		}
	}
}

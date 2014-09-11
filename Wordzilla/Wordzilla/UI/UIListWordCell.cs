
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Wordzilla
{
	public partial class UIListWordCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("UIListWordCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("UIListWordCell");

		public UIListWordCell (IntPtr handle) : base (handle)
		{
		}

		public long Id {
			get;
			set;
		}

		public string Title {
			get {
				return UITitle.Text;
			}
			set {
				UITitle.Text = value;
			}
		}

		public string Info {
			get {
				return UIInfo.Text;
			}
			set {
				UIInfo.Text = value;
			}
		}

		public EventHandler TrainingBtmEvent {
			set { UITraining.TouchUpInside += value; }
		}

		public EventHandler ListOfWordsBtmEvent {
			set { UIListOfWords.TouchUpInside += value; }
		}

		public bool TraininButtonHidden {
			set{ UITraining.Hidden = value; }
			get{ return UITraining.Hidden; }
		}

		public bool ListOfWordsButtonHidden {
			set{ UIListOfWords.Hidden = value; }
			get{ return UIListOfWords.Hidden; }
		}

		public bool TeacherEditButtonsHidden {
			set {
				UIDelete.Hidden = value;
				UIEdit.Hidden = value;
				UIDelete.Hidden = value;
				UICopy.Hidden = value;
			}
		}

		public EventHandler EditBtmEvent {
			set { UIEdit.TouchUpInside += value; }
		}

		public EventHandler DeleteBtmEvent {
			set { UIDelete.TouchUpInside += value; }
		}

		public static UIListWordCell Create ()
		{
			return (UIListWordCell)Nib.Instantiate (null, null) [0];
		}
	}
}


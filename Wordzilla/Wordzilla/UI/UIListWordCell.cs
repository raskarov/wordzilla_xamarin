
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
			set{
				UITitle.Text=value;
			}
		}

		public string Info {
			get {
				return UIInfo.Text;
			}
			set{
				UIInfo.Text=value;
			}
		}

		public EventHandler TrainingBtmEvent {
			set {UITraining.TouchUpInside+= value; }
		}

		public EventHandler EditBtmEvent {
			set {UIEdit.TouchUpInside+= value; }
		}

		public static UIListWordCell Create ()
		{
			return (UIListWordCell)Nib.Instantiate (null, null) [0];
		}

		// progressbar
		public RectangleF ProgressBarPlace {
			get {
				return UICustomProgress.Frame;
			}
			set{
				UICustomProgress.Frame=value;
			}
		}
		public RectangleF ProgressBarGreen {
			get {
				return UICustomGreen.Frame;
			}
			set{
				UICustomGreen.Frame=value;
			}
		}
		public RectangleF ProgressBarRed {
			get {
				return UICustomRed.Frame;
			}
			set{
				UICustomRed.Frame=value;
			}
		}
		public RectangleF ProgressBarYellow {
			get {
				return UICustomYellow.Frame;
			}
			set{
				UICustomYellow.Frame=value;
			}
		}
		public RectangleF ProgressBarSilver {
			get {
				return UICustomSilver.Frame;
			}
			set{
				UICustomSilver.Frame=value;
			}
		}
		// /progressbar
	}
}


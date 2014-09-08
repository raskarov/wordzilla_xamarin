
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Wordzilla
{
	public partial class UIWordEdit : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("UIWordEdit");
		public static readonly UINib Nib;

		static UIWordEdit ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				Nib = UINib.FromName ("UIWordEdit_iPhone", NSBundle.MainBundle);
		}

		public UIWordEdit (IntPtr handle) : base (handle)
		{
		}

		public static UIWordEdit Create ()
		{
			return (UIWordEdit)Nib.Instantiate (null, null) [0];
		}

		public EventHandler EditBtmEvent {
			set {UIEdit.TouchUpInside+= value; }
		}

		public EventHandler DelBtmEvent {
			set {UIDelete.TouchUpInside+= value; }
		}

		public EventHandler VoiceBtmEvent {
			set {UIVoice.TouchUpInside+= value; }
		}

		public long Id {
			get;
			set;
		}

		public string English {
			get {
				return UIEnglish.Text;
			}
			set{
				UIEnglish.Text=value;
			}
		}

		public string Russian {
			get {
				return UIRussian.Text;
			}
			set{
				UIRussian.Text=value;
			}
		}

		public string Transcr {
			get {
				return UITranscr.Text;
			}
			set{
				UITranscr.Text=value;
			}
		}

		public string Example {
			get {
				return UIExample.Text;
			}
			set{
				UIExample.Text=value;
			}
		}

	
	}
}


// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	[Register ("UIWordEdit")]
	partial class UIWordEdit
	{
		[Outlet]
		MonoTouch.UIKit.UIButton UIDelete { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIEdit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIEnglish { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIExample { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIRussian { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UITranscr { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIVoice { get; set; }

		[Action ("SpeakWord:")]
		partial void SpeakWord (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UIDelete != null) {
				UIDelete.Dispose ();
				UIDelete = null;
			}

			if (UIEnglish != null) {
				UIEnglish.Dispose ();
				UIEnglish = null;
			}

			if (UIExample != null) {
				UIExample.Dispose ();
				UIExample = null;
			}

			if (UIRussian != null) {
				UIRussian.Dispose ();
				UIRussian = null;
			}

			if (UITranscr != null) {
				UITranscr.Dispose ();
				UITranscr = null;
			}

			if (UIVoice != null) {
				UIVoice.Dispose ();
				UIVoice = null;
			}

			if (UIEdit != null) {
				UIEdit.Dispose ();
				UIEdit = null;
			}
		}
	}
}

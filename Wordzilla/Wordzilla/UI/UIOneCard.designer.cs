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
	[Register ("UIOneCard")]
	partial class UIOneCard
	{
		[Outlet]
		MonoTouch.UIKit.UIButton UIBtmExample { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView UIExampleText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UITouchCard { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UITranscription { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIVoice { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIWord { get; set; }

		[Action ("ShowExample:")]
		partial void ShowExample (MonoTouch.UIKit.UIButton sender);

		[Action ("SpeakWord:")]
		partial void SpeakWord (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UIBtmExample != null) {
				UIBtmExample.Dispose ();
				UIBtmExample = null;
			}

			if (UIExampleText != null) {
				UIExampleText.Dispose ();
				UIExampleText = null;
			}

			if (UITouchCard != null) {
				UITouchCard.Dispose ();
				UITouchCard = null;
			}

			if (UITranscription != null) {
				UITranscription.Dispose ();
				UITranscription = null;
			}

			if (UIVoice != null) {
				UIVoice.Dispose ();
				UIVoice = null;
			}

			if (UIWord != null) {
				UIWord.Dispose ();
				UIWord = null;
			}
		}
	}
}

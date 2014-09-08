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
	[Register ("UIListWordCell")]
	partial class UIListWordCell
	{
		[Outlet]
		MonoTouch.UIKit.UIView UICustomGreen { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView UICustomProgress { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView UICustomRed { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView UICustomSilver { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView UICustomYellow { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIEdit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UITitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UITraining { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UIInfo != null) {
				UIInfo.Dispose ();
				UIInfo = null;
			}

			if (UITitle != null) {
				UITitle.Dispose ();
				UITitle = null;
			}

			if (UICustomProgress != null) {
				UICustomProgress.Dispose ();
				UICustomProgress = null;
			}

			if (UICustomRed != null) {
				UICustomRed.Dispose ();
				UICustomRed = null;
			}

			if (UICustomGreen != null) {
				UICustomGreen.Dispose ();
				UICustomGreen = null;
			}

			if (UICustomSilver != null) {
				UICustomSilver.Dispose ();
				UICustomSilver = null;
			}

			if (UICustomYellow != null) {
				UICustomYellow.Dispose ();
				UICustomYellow = null;
			}

			if (UIEdit != null) {
				UIEdit.Dispose ();
				UIEdit = null;
			}

			if (UITraining != null) {
				UITraining.Dispose ();
				UITraining = null;
			}
		}
	}
}

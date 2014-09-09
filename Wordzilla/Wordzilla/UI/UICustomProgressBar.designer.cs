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
	[Register ("UICustomProgressBar")]
	partial class UICustomProgressBar
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
		
		void ReleaseDesignerOutlets ()
		{
			if (UICustomGreen != null) {
				UICustomGreen.Dispose ();
				UICustomGreen = null;
			}

			if (UICustomProgress != null) {
				UICustomProgress.Dispose ();
				UICustomProgress = null;
			}

			if (UICustomRed != null) {
				UICustomRed.Dispose ();
				UICustomRed = null;
			}

			if (UICustomSilver != null) {
				UICustomSilver.Dispose ();
				UICustomSilver = null;
			}

			if (UICustomYellow != null) {
				UICustomYellow.Dispose ();
				UICustomYellow = null;
			}
		}
	}
}

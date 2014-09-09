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
		MonoTouch.UIKit.UIButton UICopy { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIDelete { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIEdit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UIInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UIListOfWords { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UITitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UITraining { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UIDelete != null) {
				UIDelete.Dispose ();
				UIDelete = null;
			}

			if (UIEdit != null) {
				UIEdit.Dispose ();
				UIEdit = null;
			}

			if (UIInfo != null) {
				UIInfo.Dispose ();
				UIInfo = null;
			}

			if (UIListOfWords != null) {
				UIListOfWords.Dispose ();
				UIListOfWords = null;
			}

			if (UITitle != null) {
				UITitle.Dispose ();
				UITitle = null;
			}

			if (UITraining != null) {
				UITraining.Dispose ();
				UITraining = null;
			}

			if (UICopy != null) {
				UICopy.Dispose ();
				UICopy = null;
			}
		}
	}
}

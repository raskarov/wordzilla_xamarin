// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	[Register ("TrainingViewController")]
	partial class TrainingViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView UIAnswerPlace { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView UICardPlace { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel UIRussian { get; set; }

		[Action ("SelectAnswerTouch:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SelectAnswerTouch (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (UIAnswerPlace != null) {
				UIAnswerPlace.Dispose ();
				UIAnswerPlace = null;
			}
			if (UICardPlace != null) {
				UICardPlace.Dispose ();
				UICardPlace = null;
			}
			if (UIRussian != null) {
				UIRussian.Dispose ();
				UIRussian = null;
			}
		}
	}
}

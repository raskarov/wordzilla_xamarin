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
	[Register ("MainPageViewController")]
	partial class MainPageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UIGroupPass { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton UIOk { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton UISkip { get; set; }

		[Action ("NextPage:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void NextPage (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (UIGroupPass != null) {
				UIGroupPass.Dispose ();
				UIGroupPass = null;
			}
			if (UIOk != null) {
				UIOk.Dispose ();
				UIOk = null;
			}
			if (UISkip != null) {
				UISkip.Dispose ();
				UISkip = null;
			}
		}
	}
}

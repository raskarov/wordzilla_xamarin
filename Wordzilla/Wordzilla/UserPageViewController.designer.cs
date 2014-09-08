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
	[Register ("UserPageViewController")]
	partial class UserPageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView UICustomProccessBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView UIMyCards { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView UIProccessGreen { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView UIProccessRed { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView UIProccessYellow { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView UITeacherCards { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (UICustomProccessBar != null) {
				UICustomProccessBar.Dispose ();
				UICustomProccessBar = null;
			}
			if (UIMyCards != null) {
				UIMyCards.Dispose ();
				UIMyCards = null;
			}
			if (UIProccessGreen != null) {
				UIProccessGreen.Dispose ();
				UIProccessGreen = null;
			}
			if (UIProccessRed != null) {
				UIProccessRed.Dispose ();
				UIProccessRed = null;
			}
			if (UIProccessYellow != null) {
				UIProccessYellow.Dispose ();
				UIProccessYellow = null;
			}
			if (UITeacherCards != null) {
				UITeacherCards.Dispose ();
				UITeacherCards = null;
			}
		}
	}
}

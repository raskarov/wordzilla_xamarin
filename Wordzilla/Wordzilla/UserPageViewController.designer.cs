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
		UITableView UIMyCards { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView UITeacherCards { get; set; }

		[Action ("AddNewWordsVerbs:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AddNewWordsVerbs (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (UIMyCards != null) {
				UIMyCards.Dispose ();
				UIMyCards = null;
			}
			if (UITeacherCards != null) {
				UITeacherCards.Dispose ();
				UITeacherCards = null;
			}
		}
	}
}

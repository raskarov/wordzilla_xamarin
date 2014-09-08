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
	[Register ("EditWordViewController")]
	partial class EditWordViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UIEnglish { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UIExample { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UIRussian { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel UISaved { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UITranscription { get; set; }

		[Action ("EndEditing:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void EndEditing (UITextField sender);

		void ReleaseDesignerOutlets ()
		{
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
			if (UISaved != null) {
				UISaved.Dispose ();
				UISaved = null;
			}
			if (UITranscription != null) {
				UITranscription.Dispose ();
				UITranscription = null;
			}
		}
	}
}

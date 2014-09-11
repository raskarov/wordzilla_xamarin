using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Wordzilla
{
	partial class MainPageViewController : UIViewController
	{
		public MainPageViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			if (AppApi.Login())
			PerformSegue("UserPage",this);
		}

		//int nextPageState=1;
		partial void NextPage (UIButton sender)
		{	
			AppApi.Login();
			if (sender.Tag.ToString() == "UIOk"){
				AppApi.SetGroup(int.Parse(UIGroupPass.Text));
			}

			PerformSegue("UserPage",this);

			//http://wordzilla.ru/api/Words/UpdateField?pk=1&name=russian&value=test&sheetWordId=20
		//	var obb = AppApi.UpdateField(1,"russian","test1",20);
		//	Console.WriteLine(obb.ToString());
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			//if (segue.Identifier == "UserPage") 
			//	((UserPageViewController)segue.DestinationViewController).ConfigureData ();

		}
	}
}

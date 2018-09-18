using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using System;

using UIKit;

namespace Messages.iOS
{
	public partial class ViewController : ControllerBase
	{
        public MainViewModel ViewModel => AppDelegate.Locator.Main;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
            Button.SetCommand("TouchUpInside", ViewModel.BtnClick);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


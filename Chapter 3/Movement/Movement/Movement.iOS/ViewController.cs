using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using System;

using UIKit;

namespace Movement.iOS
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
			Button.AccessibilityIdentifier = "btnForward";

            Button.SetCommand(
            Events.TouchUpInside,
                ViewModel.ForwardButton
            );

        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


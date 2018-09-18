using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using System;

namespace Alert2.iOS
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
            Button.SetCommand("TouchUpInside", ViewModel.BtnAlert);

            ViewModel.ButtonText = "Click me the alert";

            this.SetBinding(
                () => ViewModel.ButtonText,
                () => Button.Title(UIKit.UIControlState.Normal),
                BindingMode.TwoWay);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


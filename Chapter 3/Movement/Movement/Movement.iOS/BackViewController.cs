using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using System;

namespace Movement.iOS
{
    public partial class BackViewController : ControllerBase
    {
        public BackViewModel ViewModel => AppDelegate.Locator.Back;

        public BackViewController(IntPtr handle) : base (handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           

            btnBackward.SetCommand(
            Events.TouchUpInside,
                ViewModel.BackButton
            );
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}

using System;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace Messages.iOS.ViewControllers
{
    public partial class SecondViewController : ControllerBase
    {
        public SecondViewModel ViewModel => AppDelegate.Locator.SecondVM;
        public SecondViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BindTextViews();
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.TextData1,
                () => txtData1.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData2,
                () => txtData2.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData3,
                () => txtData3.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData4,
                () => txtData4.Text,
                BindingMode.TwoWay);
        }
    }
}
using System;
using UIKit;
using geolocation_plugin.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace geolocation_plugin.iOS
{
    public partial class ViewController : UIViewController
    {
        MainViewModel ViewModel => AppDelegate.Locator.Main;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BindLabels();
            BindButton();
        }

        void BindButton()
        {
            btnStartListener.SetCommand("TouchUpInside", ViewModel.BtnStart);
        }

        void BindLabels()
        {
            this.SetBinding(
                () => ViewModel.Altitude,
                () => lblAlt.Text,
                BindingMode.TwoWay).WhenSourceChanges(() => updateAlt());

            this.SetBinding(
                () => ViewModel.Heading,
                () => lblHeading.Text,
                BindingMode.TwoWay).WhenSourceChanges(() => updateHeading());

            this.SetBinding(
                () => ViewModel.Latitude,
                () => lblLat.Text,
                BindingMode.TwoWay).WhenSourceChanges(() => updateLat());

            this.SetBinding(
                () => ViewModel.Longitude,
                () => lblLong.Text,
                BindingMode.TwoWay).WhenSourceChanges(() => updateLong());

            this.SetBinding(
                () => ViewModel.Speed,
                () => lblSpeed.Text,
                BindingMode.TwoWay).WhenSourceChanges(() => updateSpeed());
        }

        void updateAlt()
        {
            lblAlt.Text = ViewModel.Altitude.ToString();
        }

        void updateHeading()
        {
            lblHeading.Text = ViewModel.Heading.ToString();
        }

        void updateLat()
        {
            lblLat.Text = ViewModel.Latitude.ToString();
        }

        void updateLong()
        {
            lblLong.Text = ViewModel.Longitude.ToString();
        }

        void updateSpeed()
        {
            lblSpeed.Text = ViewModel.Speed.ToString();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}

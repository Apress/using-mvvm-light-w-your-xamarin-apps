using System;

using UIKit;
using SQLiteExample.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using SQLiteExample.iOS;

namespace SQLite.iOS
{
    public partial class ViewController : UIViewController
    {
        MainViewModel ViewModel => AppDelegate.Locator.MainVM;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BindLabels();
            BindTextViews();
            BindButton();
        }

        void BindLabels()
        {
            this.SetBinding(
                () => ViewModel.GetCurrentId.ToString(),
                () => lblCurrentId.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.GetTotal.ToString(),
                () => lblRecords.Text,
                BindingMode.TwoWay);
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.UserName,
                () => txtName.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressOne,
                () => txtAddressOne.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressTwo,
                () => txtAddressTwo.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressThree,
                () => txtAddressThree.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Email,
                () => txtEmail.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.MobileNumber,
                () => txtMobile.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Postcode,
                () => txtPostcode.Text,
                BindingMode.TwoWay);
        }

        void BindButton()
        {
            ViewModel.SetParentId = ViewModel.GetCurrentId;
            btnAddToDB.SetCommand(Events.TouchUpInside, ViewModel.BtnCommit);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}

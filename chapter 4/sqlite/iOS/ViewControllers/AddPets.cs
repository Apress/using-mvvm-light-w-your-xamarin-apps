using System;

using UIKit;
using SQLite.iOS;
using GalaSoft.MvvmLight.Helpers;

namespace SQLiteExample.iOS
{
    public partial class AddPets : UIViewController
    {
        AddPetViewModel ViewModel => AppDelegate.Locator.AddPetsVM;

        public AddPets(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindTextViews();
            BindSwitch();
            BindButton();
        }

        void BindButton()
        {
            btnAddToDatabase.SetCommand(Events.TouchUpInside, ViewModel.BtnCommit);
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.Age,
                () => txtAge.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Breed,
                () => txtBreed.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Name,
                () => txtPetName.Text,
                BindingMode.TwoWay);
        }

        void BindSwitch()
        {
            this.SetBinding(
                () => ViewModel.IsDog,
                () => swchIsDog.On,
                BindingMode.TwoWay);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


using System;

using UIKit;
using SQLite.iOS;
using GalaSoft.MvvmLight.Helpers;

namespace SQLiteExample.iOS
{
    public partial class AddHobbies : UIViewController
    {
        AddHobbiesViewModel ViewModel => AppDelegate.Locator.AddHobbiesVM;
        PickerDataModel pickerDataModel;

        public AddHobbies(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindTextViews();
            BindButton();
            BindSpinner();
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.HobbyCost,
                () => txtCost.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.HobbyDesc,
                () => txtDescription.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.HobbyName,
                () => txtHobbyName.Text,
                BindingMode.TwoWay);
        }

        void BindButton()
        {
            btnAddToDatabase.SetCommand(Events.TouchUpInside, ViewModel.BtnCommit);
        }

        void BindSpinner()
        {
            pickerDataModel = new PickerDataModel();
            foreach (var i in ViewModel.GetFrequencies)
                pickerDataModel.Items.Add(i);

            pckFrequency.Model = pickerDataModel;

            pickerDataModel.ValueChanged += delegate
            {
                ViewModel.Frequency = pickerDataModel.SelectedItem;
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


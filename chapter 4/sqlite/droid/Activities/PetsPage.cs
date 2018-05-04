using System.Windows.Input;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Command;
using SQLiteExample.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace SQLiteExample.Droid
{
    public partial class PetsPage : Android.Support.V4.App.Fragment
    {
        AddPetViewModel ViewModel => App.Locator.AddPetsVM;

        ICommand RecordAndBack
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ViewModel.BtnCommit.Execute(null);
                    MoveBackFragment();
                });
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.Pet, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            BindEditText();
            BindSwitch();
            BindButtons();
        }

        void BindEditText()
        {
            this.SetBinding(
                () => ViewModel.Name,
                () => EditName.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Breed,
                () => EditBreed.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Age,
                () => EditAge.Text,
                BindingMode.TwoWay);
        }

        void BindSwitch()
        {
            SwchDog.CheckedChange += (object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e) =>
            {
                e.SetBinding(
                    () => ViewModel.IsDog,
                    () => e.IsChecked,
                    BindingMode.TwoWay);
            };
        }

        void BindButtons()
        {
            BtnCancel.Click += delegate
            {
                MoveBackFragment();
            };

            BtnAddPet.SetCommand(Events.Click, RecordAndBack);
        }

        void MoveBackFragment()
        {
            MainViewModel.Parent = -1;
            var trans = FragmentManager.BeginTransaction();
            trans.Replace(Resource.Layout.GeneralInfo, new GeneralInfoPage());
            trans.AddToBackStack(null);
            trans.Commit();
        }
    }
}

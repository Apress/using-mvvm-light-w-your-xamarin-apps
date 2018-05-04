using Android.OS;
using Android.Views;
using SQLiteExample.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using Android.Support.V4.App;

namespace SQLiteExample.Droid
{
    public partial class GeneralInfoPage : Android.Support.V4.App.Fragment
    {
        MainViewModel ViewModel => App.Locator.MainVM;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.GeneralInfo, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            BindLabels();
            BindEditText();
            BindButtons();
        }

        void BindLabels()
        {
            this.SetBinding(
                () => ViewModel.GetCurrentId.ToString(),
                () => TxtID.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.GetTotal.ToString(),
                () => TxtTotal.Text,
                BindingMode.TwoWay);
        }

        void BindEditText()
        {
            this.SetBinding(
                () => ViewModel.UserName,
                () => EditName.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressOne,
                () => EditAddress1.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressTwo,
                () => EditAddress2.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.AddressThree,
                () => EditAddress3.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Email,
                () => EditEmail.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Postcode,
                () => EditPostcode.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.MobileNumber,
                () => EditMobile.Text,
                BindingMode.TwoWay);
        }

        void BindButtons()
        {
            BtnCommit.SetCommand(Events.Click, ViewModel.BtnCommit);

            BtnAddPet.Click += delegate
            {
                ViewModel.SetParentId = ViewModel.GetCurrentId;
                var trans = FragmentManager.BeginTransaction();
                trans.Replace(Resource.Layout.GeneralInfo, new PetsPage());
                trans.SetTransition(FragmentTransaction.TransitFragmentOpen);
                trans.AddToBackStack(null);
                trans.Commit();
            };

            BtnAddHobby.Click += delegate
            {
                ViewModel.SetParentId = ViewModel.GetCurrentId;
                var trans = FragmentManager.BeginTransaction();
                trans.Replace(Resource.Layout.GeneralInfo, new HobbiesPage());
                trans.SetTransition(FragmentTransaction.TransitFragmentOpen);
                trans.AddToBackStack(null);
                trans.Commit();
            };
        }
    }
}

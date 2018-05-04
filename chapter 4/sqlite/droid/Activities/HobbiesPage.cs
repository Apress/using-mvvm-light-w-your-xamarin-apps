using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;
using Android.Widget;
using SQLiteExample.ViewModel;
using Android.App;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace SQLiteExample.Droid
{
    public partial class HobbiesPage : Android.Support.V4.App.Fragment
    {
        AddHobbiesViewModel ViewModel => App.Locator.AddHobbiesVM;

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
            return inflater.Inflate(Resource.Layout.Hobby, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            BindEditText();
            BindSpinner();
            BindButtons();
        }

        void BindEditText()
        {
            this.SetBinding(
                () => ViewModel.HobbyName,
                () => EditName.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.HobbyDesc,
                () => EditDesc.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.HobbyCost,
                () => EditCost.Text,
                BindingMode.TwoWay);
        }

        void BindSpinner()
        {
            var freqAdapter = new ArrayAdapter<string>(EditCost.Context, Android.Resource.Layout.SimpleSpinnerItem, ViewModel.GetFrequencies);
            freqAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            SpinFreq.Adapter = freqAdapter;
            SpinFreq.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                e.SetBinding(
                    () => ViewModel.Frequency,
                    () => ViewModel.GetFrequencies[e.Position],
                    BindingMode.TwoWay);
            };
        }

        void BindButtons()
        {
            BtnAddHobby.SetCommand(Events.Click, RecordAndBack);

            BtnCancel.Click += delegate
            {
                MoveBackFragment();
            };
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

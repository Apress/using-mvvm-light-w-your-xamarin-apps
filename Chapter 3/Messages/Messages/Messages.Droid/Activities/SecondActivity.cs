using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace Messages.Droid
{
    [Activity(Label = "SecondActivity")]
    public partial class SecondActivity : ActivityBase
    {
        public SecondViewModel ViewModel => App.Locator.SecondVM;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Second);

            BindTextViews();
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.TextData1,
                () => TxtData1.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData2,
                () => TxtData2.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData3,
                () => TxtData3.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.TextData4,
                () => TxtData4.Text,
                BindingMode.TwoWay);
        }
    }
}
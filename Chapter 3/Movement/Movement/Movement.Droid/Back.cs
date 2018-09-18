
using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace Movement.Droid
{
    [Activity(Label = "Back")]
    public class BackActivity : ActivityBase
    {
        public BackViewModel ViewModel => App.Locator.Back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Back);
            
            var btnBackward = FindViewById<Button>(Resource.Id.btnBack);

            btnBackward.SetCommand(
            Events.Click,
            ViewModel.BackButton);
        }
    }
}
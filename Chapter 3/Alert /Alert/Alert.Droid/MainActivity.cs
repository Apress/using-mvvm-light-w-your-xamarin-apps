
using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace Alert.Droid
{
    [Activity (Label = "Alert.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ActivityBase
	{
        public MainViewModel ViewModel => App.Locator.Main;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var button = FindViewById<Button> (Resource.Id.myButton);

            button.SetCommand("Click", ViewModel.BtnAlert);
		}
	}
}



using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace Messages.Droid
{
    [Activity (Label = "Messages.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public partial class MainActivity : ActivityBase
	{
        public MainViewModel ViewModel => App.Locator.Main;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            
			SetContentView (Resource.Layout.Main);

            BtnClickMe.SetCommand("Click", ViewModel.BtnClick);
		}
	}
}



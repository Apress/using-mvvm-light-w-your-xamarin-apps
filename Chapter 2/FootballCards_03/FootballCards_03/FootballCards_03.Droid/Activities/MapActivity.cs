using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using AndroidUri = Android.Net.Uri;

namespace FootballCards_03.Droid
{
	[Activity(Label = "MapActivity")]
	public partial class MappingActivity : ActivityBase
	{
		public MapViewModel ViewModel => App.Locator.Map;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			GetDataFromViewModel();
			//LaunchMap();
		}

		void LaunchMap()
		{
			var geoUri = AndroidUri.Parse(string.Format("geo:{0},{1}", ViewModel.Latitude, ViewModel.Longitude));
			var mapIntent = new Intent(Intent.ActionView, geoUri);
			StartActivity(mapIntent);
		}

		void GetDataFromViewModel()
		{
			var NavService = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
			var data = NavService.GetAndRemoveParameter<List<double>>(Intent);
			if (data != null)
			{
				ViewModel.Latitude = data[0];
				ViewModel.Longitude = data[1];

				LaunchMap();
			}
		}
	}
}


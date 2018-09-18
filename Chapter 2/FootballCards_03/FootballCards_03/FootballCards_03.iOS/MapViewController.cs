using System;
using System.Collections.Generic;
using CoreLocation;
using GalaSoft.MvvmLight.Views;
using MapKit;

namespace FootballCards_03.iOS
{
	public partial class MapViewController : ControllerBase
	{
		public MapViewModel ViewModel => AppDelegate.Locator.Map;

		public MapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			GetDataFromViewModel();
			GenerateMap();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void GetDataFromViewModel()
		{
			var data = NavigationParameter as List<double>;
			if (data != null)
			{
				ViewModel.Latitude = data[0];
				ViewModel.Longitude = data[1];
			}
		}

		void GenerateMap()
		{
			mapView.ZoomEnabled = mapView.ScrollEnabled = mapView.UserInteractionEnabled = true;
			mapView.MapType = MKMapType.Standard;
			mapView.Region = new MKCoordinateRegion(
			new CLLocationCoordinate2D(ViewModel.Latitude, ViewModel.Longitude),
			new MKCoordinateSpan(.5, .5));
		}
	}
}



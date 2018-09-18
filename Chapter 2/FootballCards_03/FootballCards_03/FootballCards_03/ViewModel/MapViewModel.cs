using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace FootballCards_03
{
	public class MapViewModel : ViewModelBase
	{
		INavigationService navigationService;

		public MapViewModel(INavigationService navService)
		{
			navigationService = navService;
		}

		double latitude;
		public double Latitude
		{
			get {
				return latitude;
			}
			set {
				Set(() => Latitude, ref latitude, value, true);
			}
		}

		double longitude;
		public double Longitude
		{
			get {
				return longitude;
			}
			set {
				Set(() => Longitude, ref longitude, value, true);
			}
		}
	}
}


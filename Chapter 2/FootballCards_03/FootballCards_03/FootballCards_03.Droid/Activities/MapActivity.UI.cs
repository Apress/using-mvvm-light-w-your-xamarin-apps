using Android.Gms.Maps;

namespace FootballCards_03.Droid
{
	public partial class MappingActivity
	{
		MapView mapView;

		public MapView MapView => mapView ?? (mapView = FindViewById<MapView>(Resource.Id.mapView));
	}
}


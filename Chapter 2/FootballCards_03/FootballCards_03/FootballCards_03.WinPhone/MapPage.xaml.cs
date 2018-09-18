using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace FootballCards_03.WinPhone
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MapPage : Page
	{
        
		public MapPage ()
		{
			this.InitializeComponent ();
		}

		async Task SetMapView (Geopoint point)
		{
			await mapView.TrySetViewAsync (point, 15, 0, 0, Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
		}
	}
}

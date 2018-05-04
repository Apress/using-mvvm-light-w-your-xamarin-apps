using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.ComponentModel;
namespace geolocation_plugin.Droid
{
    public class Geolocation : IGeolocation, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        Position location;
        public Position Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        public GeoData GetLocationData()
        {
            var loc = new GeoData
            {
                Latitude = Location.Latitude,
                Longitude = Location.Longitude,
                Altitude = Location.Latitude,
                Heading = Location.Heading,
                Speed = Location.Speed
            };
            return loc;
        }

        public bool IsListening()
        {
            return CrossGeolocator.Current.IsListening;
        }

        public void StartListening()
        {
            CrossGeolocator.Current.StartListeningAsync(new System.TimeSpan(3000), 10, true);
            if (CrossGeolocator.Current.IsListening)
                CrossGeolocator.Current.GetPositionAsync(new System.TimeSpan(3000)).ContinueWith((t) =>
            {
                if (t.IsCompleted)
                    Location = t.Result;
            });
        }
    }
}

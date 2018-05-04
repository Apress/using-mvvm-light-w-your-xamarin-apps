using System;
namespace geolocation_plugin
{
    public class GeoData
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Heading { get; set; }
        public double Speed { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public double Altitude { get; set; }
    }
}

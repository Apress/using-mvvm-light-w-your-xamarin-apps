namespace geolocation_plugin
{
    public interface IGeolocation
    {
        GeoData GetLocationData();

        bool IsListening();

        void StartListening();
    }
}

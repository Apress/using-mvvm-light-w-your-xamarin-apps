using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace geolocation_plugin.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        INavigationService navService;
        IDialogService diaService;
        IGeolocation geoService;

        public MainViewModel(IDialogService dialog, INavigationService nav, IGeolocation geo)
        {
            diaService = dialog;
            navService = nav;
            geoService = geo;

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Location")
                {
                    var posn = geoService.GetLocationData();
                    Longitude = posn.Longitude;
                    Latitude = posn.Latitude;
                    Altitude = posn.Altitude;
                    Speed = posn.Speed;
                    Heading = posn.Heading;
                }
            };
        }

        RelayCommand btnStart;
        public RelayCommand BtnStart
        {
            get
            {
                return btnStart ??
                (
                    btnStart = new RelayCommand(() =>
                    {
                        if (!geoService.IsListening())
                            geoService.StartListening();
                    })
                );
            }
        }

        double longitude;
        public double Longitude
        {
            get { return longitude; }
            set { Set(() => Longitude, ref longitude, value, true); }
        }

        double latitude;
        public double Latitude
        {
            get { return latitude; }
            set { Set(() => Latitude, ref latitude, value, true); }
        }

        double altitude;
        public double Altitude
        {
            get { return altitude; }
            set { Set(() => Altitude, ref altitude, value, true); }
        }

        double speed;
        public double Speed
        {
            get { return speed; }
            set { Set(() => Speed, ref speed, value, true); }
        }

        double heading;
        public double Heading
        {
            get { return heading; }
            set { Set(() => Heading, ref heading, value, true); }
        }
    }
}
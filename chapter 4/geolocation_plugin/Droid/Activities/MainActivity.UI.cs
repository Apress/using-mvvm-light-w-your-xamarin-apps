using Android.Widget;
namespace geolocation_plugin.Droid
{
    public partial class MainActivity
    {
        TextView txtLat, txtLong, txtAlt, txtSpeed, txtHeading;
        Button btnListen;

        public TextView TxtLat => txtLat ?? (txtLat = FindViewById<TextView>(Resource.Id.txtLat));
        public TextView TxtLong => txtLong ?? (txtLong = FindViewById<TextView>(Resource.Id.txtLong));
        public TextView TxtAlt => txtAlt ?? (txtAlt = FindViewById<TextView>(Resource.Id.txtAlt));
        public TextView TxtSpeed => txtSpeed ?? (txtSpeed = FindViewById<TextView>(Resource.Id.txtSpeed));
        public TextView TxtHeading => txtHeading ?? (txtHeading = FindViewById<TextView>(Resource.Id.txtHeading));

        public Button BtnListen => btnListen ?? (btnListen = FindViewById<Button>(Resource.Id.btnListen));
    }
}

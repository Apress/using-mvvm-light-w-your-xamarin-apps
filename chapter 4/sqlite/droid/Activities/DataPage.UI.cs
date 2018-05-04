using Android.Widget;

namespace SQLiteExample.Droid
{
    public partial class DataPage
    {
        ListView lstView;

        public ListView LstView => lstView ?? (lstView = View.FindViewById<ListView>(Resource.Id.listData));
    }
}

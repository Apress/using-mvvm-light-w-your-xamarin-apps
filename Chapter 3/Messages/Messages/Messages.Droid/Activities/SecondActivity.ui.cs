using Android.Widget;

namespace Messages.Droid
{
    public partial class SecondActivity
    {
        TextView txtData1, txtData2, txtData3, txtData4;

        public TextView TxtData1 => txtData1 ?? (txtData1 = FindViewById<TextView>(Resource.Id.txtData1));
        public TextView TxtData2 => txtData2 ?? (txtData2 = FindViewById<TextView>(Resource.Id.txtData2));
        public TextView TxtData3 => txtData3 ?? (txtData3 = FindViewById<TextView>(Resource.Id.txtData3));
        public TextView TxtData4 => txtData4 ?? (txtData4 = FindViewById<TextView>(Resource.Id.txtData4));
    }
}
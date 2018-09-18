using Android.Widget;

namespace Messages.Droid
{
    public partial class MainActivity
    {
        Button btnClickMe;

        public Button BtnClickMe => btnClickMe ?? (btnClickMe = FindViewById<Button>(Resource.Id.myButton));
    }
}
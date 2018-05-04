using Android.OS;
using Android.Views;
using JimBobBennett.MvvmLight.AppCompat;

namespace SQLiteExample.Droid
{
    public partial class DataPage : Android.Support.V4.App.Fragment
    {
        ShowDataViewModel ViewModel => App.Locator.ShowDataVM;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.DataView, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            LstView.Adapter = new ListViewAdapter(AppCompatActivityBase.CurrentActivity, ViewModel.GetPersonInfo, ViewModel);
        }
    }
}

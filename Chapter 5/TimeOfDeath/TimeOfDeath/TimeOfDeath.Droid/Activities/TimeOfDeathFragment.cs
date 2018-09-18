
using Android.App;
using Android.OS;
using Android.Views;

namespace TimeOfDeath.Droid
{
    public partial class TODFragment : Fragment
    {
        View view;
        public TimeTempViewModel ViewModel => App.Locator.TimeTemp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _ = base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.founddetails, null);

            CreateBindings();
            return view;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            KillViews();
        }

        void CreateBindings()
        {

        }
    }
}

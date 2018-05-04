using Android.App;
using Android.Widget;
using Android.OS;
using JimBobBennett.MvvmLight.AppCompat;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;

namespace SQLiteExample.Droid
{
    [Activity(Label = "SQLiteExample", MainLauncher = true, Theme = "@style/Theme.AppCompat")]
    public partial class MainActivity : AppCompatActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TabLayout);

            var fragments = new Android.Support.V4.App.Fragment[]
             {
                new GeneralInfoPage(),
                new DataPage(),
             };

            var titles = CharSequence.ArrayFromStringArray(new[]
                {
                    "General",
                    "Data",
                });

            VPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

            SlidingTabs.SetupWithViewPager(VPager);
        }

        public class TabsFragmentPagerAdapter : FragmentPagerAdapter
        {
            private readonly Android.Support.V4.App.Fragment[] fragments;

            private readonly ICharSequence[] titles;

            public TabsFragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] frags, ICharSequence[] title) : base(fm)
            {
                fragments = frags;
                titles = title;
            }
            public override int Count
            {
                get
                {
                    return fragments.Length;
                }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return fragments[position];
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return titles[position];
            }
        }
    }
}


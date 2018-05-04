using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;

namespace SQLiteExample.Droid
{
    public partial class MainActivity
    {
        Toolbar toolBar;
        TabLayout sliding_tabs;
        ViewPager vPager;

        public Toolbar Toolbar => toolBar ?? (toolBar = FindViewById<Toolbar>(Resource.Id.toolbar));
        public ViewPager VPager => vPager ?? (vPager = FindViewById<ViewPager>(Resource.Id.viewpager));
        public TabLayout SlidingTabs => sliding_tabs ?? (sliding_tabs = FindViewById<TabLayout>(Resource.Id.sliding_tabs));
    }
}

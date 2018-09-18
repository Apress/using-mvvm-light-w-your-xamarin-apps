
using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;

namespace TimeOfDeath.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity : ActivityBase
    {
        ActionBar.Tab tab;
        ObservableCollection<Fragment> fragments = new ObservableCollection<Fragment>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            fragments.Add(new TODFragment());
            fragments.Add(new ConditionsFragment());

            AddTabToActionBar("Time", Resource.Drawable.crucifix_colour);
            AddTabToActionBar("Conditions", Resource.Drawable.weather_colour);
        }

        void AddTabToActionBar(string text, int iconResourceId)
        {
            tab = ActionBar.NewTab().SetTag(text).SetText(text).SetIcon(iconResourceId);

            /* uncomment and comment out one of the two below to see the difference in operation */

            tab.TabSelected += TabOnTabSelected;
            //tab.SetCommand<ActionBar.TabEventArgs>("TabSelected", TabClicked);
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            var tabNo = sender as ActionBar.Tab;
            var frag = fragments[tabNo.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}



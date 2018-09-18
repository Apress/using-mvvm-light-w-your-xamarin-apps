using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace TimeOfDeath.Droid
{
    [Application(Icon = "@drawable/icon")]
    public class App : Application
    {
        static ViewModelLocator locator;

        public App(IntPtr h, JniHandleOwnership jho)
            : base(h, jho)
        {
        }

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    // First time initialisation
                    var nav = new NavigationService()
;
                    // configure the navigation service
                    nav.Configure(ViewModelLocator.StateFoundKey, typeof(MainActivity));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}

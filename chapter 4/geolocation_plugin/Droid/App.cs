using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace geolocation_plugin.Droid
{
    [Application(Icon = "@mipmap/icon")]
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
                    var nav = new NavigationService();

                    // configure the navigation service
                    nav.Configure(ViewModelLocator.MainKey, typeof(MainActivity));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<IDialogService, DialogService>();
                    SimpleIoc.Default.Register<IGeolocation, Geolocation>();

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}

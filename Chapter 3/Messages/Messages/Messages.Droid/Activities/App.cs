using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;

namespace Messages.Droid
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
                    var nav = new NavigationService();

                    // configure the navigation service
                    nav.Configure(ViewModelLocator.MainViewKey, typeof(MainActivity));
                    nav.Configure(ViewModelLocator.SecondViewKey, typeof(SecondActivity));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}
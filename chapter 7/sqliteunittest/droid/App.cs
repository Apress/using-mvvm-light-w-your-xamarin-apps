using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SQLiteUnitTest.ViewModel;

namespace SQLiteUnitTest.Droid
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
                    var nav = new NavigationService();

                    // configure the navigation service
                    nav.Configure(ViewModelLocator.MainViewKey, typeof(MainView));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<ISQLConnection, SQLConnection>();

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}

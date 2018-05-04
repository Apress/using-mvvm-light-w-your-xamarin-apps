using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace SQLiteExample.Droid
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
                    nav.Configure(ViewModelLocator.ShowDataKey, typeof(DataPage));
                    nav.Configure(ViewModelLocator.AddPetsKey, typeof(PetsPage));
                    nav.Configure(ViewModelLocator.AddHobbiesKey, typeof(HobbiesPage));
                    nav.Configure(ViewModelLocator.MainKey, typeof(GeneralInfoPage));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<ISqLiteConnectionFactory, SQLiteConnectionFactory>();

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}

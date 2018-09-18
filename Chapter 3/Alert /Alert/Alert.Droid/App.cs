using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;

namespace Alert.Droid
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
                    SimpleIoc.Default.Register<IDialogService, DialogService>();
                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}
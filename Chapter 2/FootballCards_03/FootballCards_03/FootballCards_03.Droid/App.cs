using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;

namespace FootballCards_03.Droid
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
			get {
				if (locator == null)
				{
					// First time initialisation
					var nav = new NavigationService();

					// configure the navigation service
					nav.Configure(ViewModelLocator.MainPageKey, typeof(MainActivity));
					nav.Configure(ViewModelLocator.MapPageKey, typeof(MappingActivity));

					// register with the Navigation Service
					SimpleIoc.Default.Register<INavigationService>(() => nav);

					locator = new ViewModelLocator();
				}

				return locator;
			}
		}
	}
}


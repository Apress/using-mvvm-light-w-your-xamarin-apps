using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace FootballCards_03
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>

		// set up keys for the pages
		public const string MainPageKey = "FirstPage";
		public const string MapPageKey = "MapPage";

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();

			// add the map view model
			SimpleIoc.Default.Register<MapViewModel>();
		}

		public MainViewModel Main
		{
			get {
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		// add the map page propery
		public MapViewModel Map
		{
			get {
				return ServiceLocator.Current.GetInstance<MapViewModel>();
			}
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}
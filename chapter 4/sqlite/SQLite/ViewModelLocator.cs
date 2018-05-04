using GalaSoft.MvvmLight.Ioc;
using SQLiteExample.ViewModel;

namespace SQLiteExample
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public const string MainKey = "MainVM";
        public const string AddPetsKey = "AddPetsVM";
        public const string AddHobbiesKey = "AddHobbiesVM";
        public const string ShowDataKey = "ShowDataVM";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddPetViewModel>();
            SimpleIoc.Default.Register<AddHobbiesViewModel>();
            SimpleIoc.Default.Register<ShowDataViewModel>();
        }

        public MainViewModel MainVM => SimpleIoc.Default.GetInstance<MainViewModel>();

        public AddPetViewModel AddPetsVM => SimpleIoc.Default.GetInstance<AddPetViewModel>();

        public AddHobbiesViewModel AddHobbiesVM => SimpleIoc.Default.GetInstance<AddHobbiesViewModel>();

        public ShowDataViewModel ShowDataVM => SimpleIoc.Default.GetInstance<ShowDataViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
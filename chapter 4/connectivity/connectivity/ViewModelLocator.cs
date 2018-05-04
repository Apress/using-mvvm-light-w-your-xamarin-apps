using connectivity.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace connectivity
{
    public class ViewModelLocator
    {
        public const string MainKey = "Main";
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
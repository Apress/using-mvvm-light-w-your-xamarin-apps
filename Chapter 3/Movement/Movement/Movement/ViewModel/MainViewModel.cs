using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Movement
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        INavigationService navService;
        RelayCommand forwardButtonCommand;

        public MainViewModel(INavigationService nav)
        {
            navService = nav;
        }

        public RelayCommand ForwardButton
        {
            get
            {
                return forwardButtonCommand ??
                    (forwardButtonCommand = new RelayCommand(
                    () =>
                    {
                        navService.NavigateTo(ViewModelLocator.BackViewKey);
                    }));
            }
        }
    }
}
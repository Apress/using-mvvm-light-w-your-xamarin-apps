using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Movement
{
    public class BackViewModel
    {
        INavigationService navService;
        RelayCommand backButtonCommand;

        public BackViewModel(INavigationService nav)
        {
            navService = nav;
        }

        public RelayCommand BackButton
        {
            get
            {
                return backButtonCommand ??
                    (backButtonCommand = new RelayCommand(
                    () =>
                    {
                        navService.GoBack();
                    }));
            }
        }
    }
}

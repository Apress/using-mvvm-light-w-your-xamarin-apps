using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;

namespace connectivity.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        INavigationService navService;
        IDialogService diaService;

        public MainViewModel(IDialogService dialog, INavigationService nav)
        {
            diaService = dialog;
            navService = nav;
        }

        bool goWebsite;
        public bool GoWebsite
        {
            get => goWebsite;
            set { Set(() => GoWebsite, ref goWebsite, value, true); }
        }

        RelayCommand websiteCommand;
        public RelayCommand WebsiteCommand => websiteCommand ?? (websiteCommand = new RelayCommand(async () =>
                {
                    if (!IsOnline)
                        await diaService.ShowMessage("You are not connected to a network", "Network error", "OK", () => GoWebsite = false);
                    else
                        GoWebsite = true;

                    // the following line resets websiteCommand - if you don't, you'll only be able to fire the command once
                    websiteCommand = null;
                }));
    }
}
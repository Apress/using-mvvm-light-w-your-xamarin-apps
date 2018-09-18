using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Alert3
{

    public class MainViewModel : ViewModelBase
    {
            RelayCommand btnAlert;

        public MainViewModel()
        {
        }

        public RelayCommand BtnAlert
        {
            get
            {
                return btnAlert ??
                    (btnAlert = new RelayCommand(
                    async () =>
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        var result = await dialog.ShowMessage("Do you want to take the blue pill or red pill?",
                            "Reality time", "Red pill", "Blue pill", async(r) =>
                            {
                                await dialog.ShowMessage(string.Format("You picked the {0} pill", r ? "red" : "blue"), "Yummy");
                            });
                        if (result)
                        {
                            await dialog.ShowMessage("Welcome Nero...", "Message from the Matrix");
                        }
                    }));
            }
        }
    }
}
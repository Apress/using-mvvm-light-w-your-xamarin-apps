using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Alert2
{
    public class MainViewModel : ViewModelBase
    {
        RelayCommand btnAlert;

        public MainViewModel()
        {
            
        }

        string buttonText;
        public string ButtonText
        {
            get
            {
                return buttonText;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                Set(()=>ButtonText, ref buttonText, value);
            }
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
                        await dialog.ShowError("A message from the VC", "Hello world!", "OK", () =>
                        {
                            ButtonText = "You clicked me";
                        });
                    }));
            }
        }
    }
}
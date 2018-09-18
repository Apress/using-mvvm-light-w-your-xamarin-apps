using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Alert
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        RelayCommand btnAlert;

        public MainViewModel()
        {
        }

        public RelayCommand BtnAlert
        {
            get {
                return btnAlert ??
                    (btnAlert = new RelayCommand(
                    async () =>
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        await dialog.ShowError("A message from the VC", "Hello world!", "OK", null);
                    }));
            }
        }
    }
}
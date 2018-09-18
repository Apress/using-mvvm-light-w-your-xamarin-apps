using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Messages.Models;

namespace Messages
{
    public class MainViewModel : ViewModelBase
    {
        INavigationService navService;
        public MainViewModel(INavigationService nav)
        {
            navService = nav;
        }

        RelayCommand btnClick;
        public RelayCommand BtnClick
        {
            get
            {
                return btnClick ??
                    (btnClick = new RelayCommand(
                    () =>
                    {
                        // create the instance of the model
                        var dataModel = new MessageData("This is line 1", "Line 2 contains this", "MVVM Light", "Xamarin rocks!");

                        // Send the message. We are going to specify a key. We don't need it for this code
                        // but if we had more viewmodels and don't want them all to listen for this broadcast,
                        // the key will tell those viewmodels who aren't listening for this key to ignore it.
                        Messenger.Default.Send(new NotificationMessage<MessageData>(dataModel, "SelectData"));

                        // go to the next viewmodel
                        navService.NavigateTo(ViewModelLocator.SecondViewKey);
                    }));
            }
        }
    }
}
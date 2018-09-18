using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Messages.Models;

namespace Messages
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel()
        {
            Messenger.Default.Register<NotificationMessage<MessageData>>(this, (message) =>
            {
                // Gets the message object.
                var data = message.Content;

                // Checks the associated action.
                switch (message.Notification)
                {
                    case "SelectData":
                        TextData1 = data.Data1;
                        TextData2 = data.Data2;
                        TextData3 = data.Data3;
                        TextData4 = data.Data4;
                        break;
                    default:
                        break;
                }
            });
        }

        string textData1;
        public string TextData1
        {
            get { return textData1; }
            set
            {
                Set(() => TextData1, ref textData1, value);
            }
        }

        string textData2;
        public string TextData2
        {
            get { return textData2; }
            set
            {
                Set(() => TextData2, ref textData2, value);
            }
        }

        string textData3;
        public string TextData3
        {
            get { return textData3; }
            set
            {
                Set(() => TextData3, ref textData3, value);
            }
        }

        string textData4;
        public string TextData4
        {
            get { return textData4; }
            set
            {
                Set(() => TextData4, ref textData4, value);
            }
        }
    }
}

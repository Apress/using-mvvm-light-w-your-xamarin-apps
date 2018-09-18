using GalaSoft.MvvmLight.Messaging;

namespace Messages.Models
{
    public class MessageData : MessageBase
    {
        public MessageData(string d1, string d2, string d3, string d4)
        {
            Data1 = d1;
            Data2 = d2;
            Data3 = d3;
            Data4 = d4;
        }

        public string Data1 { get; private set; }
        public string Data2 { get; private set; }
        public string Data3 { get; private set; }
        public string Data4 { get; private set; }
    }
}

using System;
using GalaSoft.MvvmLight;
namespace connectivity.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        static bool isOnline;
        public bool IsOnline
        {
            get => isOnline;
            set { Set(() => IsOnline, ref isOnline, value, true); }
        }
    }
}

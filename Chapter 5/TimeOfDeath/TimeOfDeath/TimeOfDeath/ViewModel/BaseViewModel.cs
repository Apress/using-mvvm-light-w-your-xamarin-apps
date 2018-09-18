using GalaSoft.MvvmLight;
using TimeOfDeath.Models;
namespace TimeOfDeath
{
    public class BaseViewModel : ViewModelBase
    {
        static CalcData calcData;
        public CalcData CalcData
        {
            get { return calcData; }
            set { Set(() => CalcData, ref calcData, value); }
        }
    }
}

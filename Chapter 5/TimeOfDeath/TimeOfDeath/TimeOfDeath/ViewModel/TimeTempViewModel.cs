using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using TimeOfDeath.Interfaces;
using System.Collections.Generic;

namespace TimeOfDeath
{
    public class TimeTempViewModel : BaseViewModel
    {
        INavigationService navService;
        ICalculateData calcData;

        public TimeTempViewModel(INavigationService nav, ICalculateData calc)
        {
            navService = nav;
            calcData = calc;
        }

        public DateTime SetDate
        {
            get { return calcData.GetData<DateTime>("date"); }
            set
            {
                calcData.SetData("date", value);
                RaisePropertyChanged("SetDate");
            }
        }

        public double TempBody
        {
            get { return calcData.GetData<double>("tempWeight"); }
            set
            {
                calcData.SetData("tempWeight", value);
                RaisePropertyChanged("tempWeight");
            }
        }

        public double TempSurround
        {
            get { return calcData.GetData<double>("tempSurround"); }
            set
            {
                calcData.SetData("tempSurround", value);
                RaisePropertyChanged("tempSurround");
            }
        }

        public double BodyWeight
        {
            get { return calcData.GetData<double>("bodyWeight"); }
            set
            {
                calcData.SetData("bodyWeight", value);
            }
        }

        bool inKilos;
        public bool InKilos
        {
            get { return inKilos; }
            set { Set(() => InKilos, ref inKilos, value); }
        }
    }
}

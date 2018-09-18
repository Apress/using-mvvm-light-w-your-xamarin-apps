using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using TimeOfDeath.Extensions;
using TimeOfDeath.Helpers;
using TimeOfDeath.Interfaces;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace TimeOfDeath
{
    public class StateFoundViewModel : ViewModelBase
    {
        INavigationService navService;
        ICalculateData calcData;

        public StateFoundViewModel(INavigationService nav, ICalculateData data)
        {
            navService = nav;
            calcData = data;
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

        public double TempBody
        {
            get { return calcData.GetData<double>("tempBody"); }
            set
            {
                calcData.SetData("tempBody", value);
                RaisePropertyChanged("tempBody");
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

        string foundInWater;
        public string FoundInWater
        {
            get { return foundInWater; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var r = GetFoundWater.IndexOf(value);
                    if (r == 2)
                    {
                        FoundWater = true;
                        SetPA = 0;
                    }
                    else
                        FoundWater = false;
                    SetA = -2;
                    SetW = r;
                }
                Set(() => FoundInWater, ref foundInWater, value);
            }
        }
        int SetW
        {
            get { return calcData.GetData<int>("setW"); }
            set
            {
                calcData.SetData("setW", value);
            }
        }

        string foundInAir;
        public string FoundInAir
        {
            get { return foundInAir; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    SetA = GetFoundAir.IndexOf(value);
                    SetPA = SetW = -1;
                }
                Set(() => FoundInAir, ref foundInAir, value);
            }
        }
        int SetA
        {
            get { return calcData.GetData<int>("setA"); }
            set
            {
                calcData.SetData("setA", value);
            }
        }

        string bodyCondition;
        public string BodyCondition
        {
            get { return bodyCondition; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var r = GetBodyLayers.IndexOf(value);
                    if (r >= 6)
                    {
                        SetW = 1;
                        SetA = -2;
                        InWater = true;
                        Air = false;
                    }
                    else
                    {
                        SetW = 0;
                        InWater = false;
                        Air = true;
                    }
                    SetP = r;
                }
                Set(() => BodyCondition, ref bodyCondition, value);
            }
        }
        int SetP
        {
            get { return calcData.GetData<int>("setP"); }
            set
            {
                calcData.SetData("setP", value);
            }
        }

        string pulledFromWater;
        public string PulledFromWater
        {
            get { return pulledFromWater; }
            set
            {
                SetA = -2;
                if (!string.IsNullOrEmpty(value))
                    SetPA = GetPulledWater.IndexOf(value);
                Set(() => PulledFromWater, ref pulledFromWater, value);
            }
        }
        int SetPA
        {
            get { return calcData.GetData<int>("setPA"); }
            set
            {
                calcData.SetData("setPA", value);
            }
        }

        bool foundWater;
        public bool FoundWater
        {
            get { return foundWater; }
            set { Set(() => FoundWater, ref foundWater, value, true); }
        }

        public bool InWater { get; set; }
        public bool Air { get; set; }

        public DateTime TODDate
        {
            get { return calcData.GetData<DateTime>("date"); }
        }

        public string TimeOfDeath
        {
            get { return calcData.GetData<DateTime>("timeOfDeath").ToShortTimeString(); }
        }

        public string DateOfDeath
        {
            get { return calcData.GetData<DateTime>("dateOfDeath").ToShortDateString(); }
        }

        RelayCommand btnCalculateResults;
        public RelayCommand BtnCalculateResults
        {
            get
            {
                return btnCalculateResults ??
                    (
                        btnCalculateResults = new RelayCommand(
                            async () =>
                            {
                                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                if (TempBody < TempSurround)
                                {
                                    await dialog.ShowError("Time Of Death Error", "Body temperature must be greater than surrounds",
                                        "OK", null);
                                    return;
                                }
                                if (BodyWeight <= 0)
                                {
                                    await dialog.ShowError("Time Of Death Error", "The body has to have some weight", "OK", null);
                                    return;
                                }
                                if (TempBody == -999)
                                {
                                    await dialog.ShowError("Time Of Death Error", "Temp of surround = null", "OK", null);
                                    return;
                                }
                                if (TempSurround == -999)
                                {
                                    await dialog.ShowError("Time Of Death Error", "Temp of surround = null", "OK", null);
                                    return;
                                }
                                new Calculation(calcData.GetCalcData()).CalcTOD(TODDate);
                                await dialog.ShowMessage("Time of Death result",
                                    string.Format("Death occured on or before {0}\nAt or around {1}", DateOfDeath, TimeOfDeath),
                                    "OK", null);
                            }));
            }
        }

        public List<string> GetBodyLayers
        {
            get
            {
                return new List<string>
                {
                    "Dry and naked", "Dry with 1-2 thin layers", "Dry with 2-3 thin layers", "Dry with 3-4 thin layers", "Dry with 1-2 thicker layers", "Dry with more thin or thicker layers",
                    "Wet and naked", "Wet with 1-2 thin wet layers", "Wet with 2 thicker wet layers", "Wet with 2 or more thicker wet layers",
                };
            }
        }

        public List<string> GetFoundAir
        {
            get
            {
                return new List<string> { "still", "moving", "unknown" };
            }
        }

        public List<string> GetFoundWater
        {
            get
            {
                return new List<string> { "moving", "still", "pulled from water", "unknown" };
            }
        }

        public List<string> GetPulledWater
        {
            get
            {
                return new List<string> { "still", "moving" };
            }
        }
    }
}
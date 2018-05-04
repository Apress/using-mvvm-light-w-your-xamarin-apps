using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace SQLiteExample
{
    public class AddHobbiesViewModel : ViewModelBase
    {
        IRepository sqlService;

        public AddHobbiesViewModel(IRepository repo)
        {
            sqlService = repo;
        }

        int parentId;
        public int ParentId
        {
            get { return parentId; }
            set { Set(() => ParentId, ref parentId, value, true); }
        }

        string hobbyName;
        public string HobbyName
        {
            get { return hobbyName; }
            set { Set(() => HobbyName, ref hobbyName, value, true); }
        }

        string description;
        public string HobbyDesc
        {
            get { return description; }
            set { Set(() => HobbyDesc, ref description, value, true); }
        }

        double cost;
        public double HobbyCost
        {
            get { return cost; }
            set { Set(() => HobbyCost, ref cost, value, true); }
        }

        public List<string> GetFrequencies
        {
            get
            {
                return new List<string> { "Daily", "A few times a week", "Weekly", "A few times a month", "Monthly", "A few times a year", "Year", "When weather allows" };
            }
        }

        string frequency;
        public string Frequency
        {
            get { return frequency; }
            set { Set(() => Frequency, ref frequency, value, true); }
        }

        RelayCommand btnCommit;
        public RelayCommand BtnCommit
        {
            get
            {
                return btnCommit ??
                    (btnCommit = new RelayCommand(
                    () =>
                    {
                        var pet = new Hobbies
                        {
                            ParentId = this.ParentId,
                            HobbyName = this.HobbyName,
                            Description = this.HobbyDesc,
                            Cost = HobbyCost,
                            FreqencyAttended = Frequency
                        };
                        sqlService.SaveData(pet);
                    }));
            }
        }
    }
}

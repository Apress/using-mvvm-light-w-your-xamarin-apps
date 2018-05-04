using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Dynamic;

namespace SQLiteExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly IRepository sqliteService;

        public MainViewModel(IRepository sql)
        {
            sqliteService = sql;
        }

        public int GetCurrentId
        {
            get
            {
                return sqliteService.GetID<PersonalInfo>();
            }
        }

        public int GetTotal
        {
            get { return sqliteService.GetList<PersonalInfo>().Count; }
        }

        public static int Parent;
        public int SetParentId
        {
            get { return Parent; }
            set { Set(() => SetParentId, ref Parent, value); }
        }

        string name;
        public string UserName
        {
            get { return name; }
            set { Set(() => UserName, ref name, value, true); }
        }

        string addressOne;
        public string AddressOne
        {
            get { return addressOne; }
            set { Set(() => AddressOne, ref addressOne, value, true); }
        }

        string addressTwo;
        public string AddressTwo
        {
            get { return addressTwo; }
            set { Set(() => AddressTwo, ref addressTwo, value, true); }
        }

        string addressThree;
        public string AddressThree
        {
            get { return addressThree; }
            set { Set(() => AddressThree, ref addressThree, value, true); }
        }

        string postcode;
        public string Postcode
        {
            get { return postcode; }
            set { Set(() => Postcode, ref postcode, value, true); }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { Set(() => Email, ref email, value, true); }
        }

        string mobileNumber;
        public string MobileNumber
        {
            get { return mobileNumber; }
            set { Set(() => MobileNumber, ref mobileNumber, value, true); }
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
                        var person = new PersonalInfo
                        {
                            Name = UserName,
                            AddressLineOne = AddressOne,
                            AddressLineTwo = AddressTwo,
                            AddressLineThree = AddressThree,
                            PostCode = Postcode,
                            EmailAddress = Email,
                            MobilePhone = MobileNumber
                        };
                        sqliteService.SaveData(person);
                    }));
            }
        }
    }
}
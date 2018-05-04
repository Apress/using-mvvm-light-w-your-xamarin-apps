using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SQLiteExample
{
    public class AddPetViewModel : ViewModelBase
    {
        IRepository sqlService;

        public AddPetViewModel(IRepository repo)
        {
            sqlService = repo;
        }

        int parent;
        public int Parent
        {
            get { return parent; }
            set { Set(() => Parent, ref parent, value, true); }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value, true); }
        }

        string breed;
        public string Breed
        {
            get { return breed; }
            set { Set(() => Breed, ref breed, value, true); }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { Set(() => Age, ref age, value, true); }
        }

        bool isDog;
        public bool IsDog
        {
            get { return isDog; }
            set { Set(() => IsDog, ref isDog, value, true); }
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
                        var pet = new Pets
                        {
                            ParentId = Parent,
                            PetsName = Name,
                            Breed = this.Breed,
                            PetsAge = Age,
                            IsDog = this.IsDog
                        };
                        sqlService.SaveData(pet);
                    }));
            }
        }
    }
}

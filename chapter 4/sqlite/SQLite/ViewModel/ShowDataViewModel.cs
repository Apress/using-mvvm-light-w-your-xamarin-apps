using System.Collections.Generic;
using GalaSoft.MvvmLight;
using System.Linq;

namespace SQLiteExample
{
    public class ShowDataViewModel : ViewModelBase
    {
        IRepository sqlService;

        public ShowDataViewModel(IRepository repo)
        {
            sqlService = repo;
        }

        public List<PersonalInfo> GetPersonInfo
        {
            get { return sqlService.GetList<PersonalInfo>(); }
        }

        int parentId;
        public int ParentId
        {
            get { return parentId; }
            set { Set(() => ParentId, ref parentId, value, true); }
        }

        public bool GetHasPet
        {
            get { return sqlService.GetList<Pets>().Count(t => t.ParentId == ParentId) != 0; }
        }

        public bool GetHasHobbies
        {
            get { return sqlService.GetList<Hobbies>().Count(t => t.ParentId == ParentId) != 0; }
        }
    }
}

using Android.Widget;

namespace SQLiteExample.Droid
{
    public partial class HobbiesPage
    {
        EditText editName, editDesc, editCost;
        Spinner spinFrequency;
        Button btnAddHobby, btnCancel;

        public EditText EditName => editName ?? (editName = View.FindViewById<EditText>(Resource.Id.editName));
        public EditText EditDesc => editDesc ?? (editDesc = View.FindViewById<EditText>(Resource.Id.editDescription));
        public EditText EditCost => editCost ?? (editCost = View.FindViewById<EditText>(Resource.Id.editCost));

        public Spinner SpinFreq => spinFrequency ?? (spinFrequency = View.FindViewById<Spinner>(Resource.Id.spinFrequency));

        public Button BtnAddHobby => btnAddHobby ?? (btnAddHobby = View.FindViewById<Button>(Resource.Id.btnAddHobby));
        public Button BtnCancel => btnCancel ?? (btnCancel = View.FindViewById<Button>(Resource.Id.btnCancel));
    }
}

using Android.Widget;

namespace SQLiteExample.Droid
{
    public partial class PetsPage
    {
        EditText editName, editBreed, editAge;
        Switch swchDog;
        Button btnAddPet, btnCancel;

        public EditText EditName => editName ?? (editName = View.FindViewById<EditText>(Resource.Id.editName));
        public EditText EditBreed => editBreed ?? (editBreed = View.FindViewById<EditText>(Resource.Id.editBreed));
        public EditText EditAge => editAge ?? (editAge = View.FindViewById<EditText>(Resource.Id.editAge));

        public Switch SwchDog => swchDog ?? (swchDog = View.FindViewById<Switch>(Resource.Id.swchIsDog));

        public Button BtnAddPet => btnAddPet ?? (btnAddPet = View.FindViewById<Button>(Resource.Id.btnCommit));
        public Button BtnCancel => btnCancel ?? (btnCancel = View.FindViewById<Button>(Resource.Id.btnCancel));
    }
}

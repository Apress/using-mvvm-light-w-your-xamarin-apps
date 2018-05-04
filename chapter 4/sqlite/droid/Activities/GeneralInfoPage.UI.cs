using Android.Widget;

namespace SQLiteExample.Droid
{
    public partial class GeneralInfoPage
    {
        TextView txtID, txtTotal;
        EditText editName, editAddress1, editAddress2, editAddress3, editPostcode, editEmail, editMobile;
        Button btnAddPet, btnAddHobby, btnCommit;

        public TextView TxtID => txtID ?? (txtID = View.FindViewById<TextView>(Resource.Id.txtID));
        public TextView TxtTotal => txtTotal ?? (txtTotal = View.FindViewById<TextView>(Resource.Id.txtTotal));

        public EditText EditName => editName ?? (editName = View.FindViewById<EditText>(Resource.Id.editName));
        public EditText EditAddress1 => editAddress1 ?? (editAddress1 = View.FindViewById<EditText>(Resource.Id.editAddress1));
        public EditText EditAddress2 => editAddress2 ?? (editAddress2 = View.FindViewById<EditText>(Resource.Id.editAddress2));
        public EditText EditAddress3 => editAddress3 ?? (editAddress3 = View.FindViewById<EditText>(Resource.Id.editAddress3));
        public EditText EditPostcode => editPostcode ?? (editPostcode = View.FindViewById<EditText>(Resource.Id.editPostcode));
        public EditText EditEmail => editEmail ?? (editEmail = View.FindViewById<EditText>(Resource.Id.editEmail));
        public EditText EditMobile => editMobile ?? (editMobile = View.FindViewById<EditText>(Resource.Id.editMobile));

        public Button BtnAddPet => btnAddPet ?? (btnAddPet = View.FindViewById<Button>(Resource.Id.btnAddPet));
        public Button BtnAddHobby => btnAddHobby ?? (btnAddHobby = View.FindViewById<Button>(Resource.Id.btnAddHobby));
        public Button BtnCommit => btnCommit ?? (btnCommit = View.FindViewById<Button>(Resource.Id.btnCommit));
    }
}

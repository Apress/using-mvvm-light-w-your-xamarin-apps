using Android.Widget;
namespace TimeOfDeath.Droid
{
    public partial class TODFragment
    {
        EditText editDate, editTime, tempBody, tempSurround, weightBody;
        CheckBox weightBodyKG;

        void KillViews()
        {
            editDate = editTime = tempBody = tempSurround = weightBody = null;
            weightBodyKG = null;
        }

        public EditText EditDate => editDate ?? (editDate = view.FindViewById<EditText>(Resource.Id.editDate));
        public EditText EditTime => editTime ?? (editTime = view.FindViewById<EditText>(Resource.Id.editTime));
        public EditText EditTempBody => tempBody ?? (tempBody = view.FindViewById<EditText>(Resource.Id.tempBody));
        public EditText EditTempSurround => tempSurround ?? (tempSurround = view.FindViewById<EditText>(Resource.Id.tempSurround));
        public EditText EditWeightBody => weightBody ?? (weightBody = view.FindViewById<EditText>(Resource.Id.weightBody));

        public CheckBox ChkBoxWeightKg => weightBodyKG ?? (weightBodyKG = view.FindViewById<CheckBox>(Resource.Id.weightBodyKG));
    }
}

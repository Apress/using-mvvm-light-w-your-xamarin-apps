using Android.Widget;

namespace FootballCards_03.Droid
{
	public partial class MainActivity
	{
		// create the private references to the objects

		Button btnShuffle, btnMap;
		TextView txtTeamName, txtStadium, txtCapacity;
		EditText editShuffles;

		// create the public properties for the objects

		public Button BtnShuffle => btnShuffle ?? (btnShuffle = FindViewById<Button>(Resource.Id.btnShuffle));
		public Button BtnMap => btnMap ?? (btnMap = FindViewById<Button>(Resource.Id.btnShowMap));

		public TextView TxtTeamName => txtTeamName ?? (txtTeamName = FindViewById<TextView>(Resource.Id.txtTeamName));
		public TextView TxtStadium => txtStadium ?? (txtStadium = FindViewById<TextView>(Resource.Id.txtStadium));
		public TextView TxtCapacity => txtCapacity ?? (txtCapacity = FindViewById<TextView>(Resource.Id.txtCapacity));

		public EditText EditShuffles => editShuffles ?? (editShuffles = FindViewById<EditText>(Resource.Id.editShuffles));
	}
}


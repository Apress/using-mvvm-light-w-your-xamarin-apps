using System;

using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace FootballCards_02.iOS
{
	public partial class ViewController : UIViewController
	{
		public MainViewModel ViewModel => AppDelegate.Locator.Main;

		public ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			BindLabels();

			BindTextField();

			SetCommands();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void BindLabels()
		{
			this.SetBinding(
			() => ViewModel.TeamName,
			() => lblTeamName.Text,
			BindingMode.TwoWay);

			this.SetBinding(
			() => ViewModel.StadiumName,
			() => lblStadium.Text,
			BindingMode.TwoWay);

			this.SetBinding(
			() => ViewModel.Capacity,
				() => lblCapacity.Text,
			BindingMode.TwoWay);
		}

		void SetCommands()
		{
			btnShuffle.SetCommand(
			Events.TouchUpInside,
				ViewModel.ButtonClicked
			);
		}

		void BindTextField()
		{
			this.SetBinding(
			() => txtShuffles.Text).UpdateSourceTrigger(Events.EditingChanged).WhenSourceChanges(() => ViewModel.TextNumberOfShuffles = txtShuffles.Text);
		}
	}
}


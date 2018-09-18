// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TimeOfDeath.iOS
{
	[Register ("StateFoundViewController")]
	partial class StateFoundViewController
	{
		[Outlet]
		UIKit.UIButton btnCalc { get; set; }

		[Outlet]
		UIKit.UILabel lblBody { get; set; }

		[Outlet]
		UIKit.UILabel lblFoundAir { get; set; }

		[Outlet]
		UIKit.UILabel lblFoundWater { get; set; }

		[Outlet]
		UIKit.UILabel lblPulledWater { get; set; }

		[Outlet]
		UIKit.UITabBarItem tabCondition { get; set; }

		[Outlet]
		UIKit.UITextField txtBody { get; set; }

		[Outlet]
		UIKit.UITextField txtFoundAir { get; set; }

		[Outlet]
		UIKit.UITextField txtFoundWater { get; set; }

		[Outlet]
		UIKit.UITextField txtPulledWater { get; set; }

		[Outlet]
		UIKit.UIView vwView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCalc != null) {
				btnCalc.Dispose ();
				btnCalc = null;
			}

			if (lblBody != null) {
				lblBody.Dispose ();
				lblBody = null;
			}

			if (lblFoundAir != null) {
				lblFoundAir.Dispose ();
				lblFoundAir = null;
			}

			if (lblFoundWater != null) {
				lblFoundWater.Dispose ();
				lblFoundWater = null;
			}

			if (lblPulledWater != null) {
				lblPulledWater.Dispose ();
				lblPulledWater = null;
			}

			if (tabCondition != null) {
				tabCondition.Dispose ();
				tabCondition = null;
			}

			if (txtBody != null) {
				txtBody.Dispose ();
				txtBody = null;
			}

			if (txtFoundAir != null) {
				txtFoundAir.Dispose ();
				txtFoundAir = null;
			}

			if (txtFoundWater != null) {
				txtFoundWater.Dispose ();
				txtFoundWater = null;
			}

			if (txtPulledWater != null) {
				txtPulledWater.Dispose ();
				txtPulledWater = null;
			}

			if (vwView != null) {
				vwView.Dispose ();
				vwView = null;
			}
		}
	}
}

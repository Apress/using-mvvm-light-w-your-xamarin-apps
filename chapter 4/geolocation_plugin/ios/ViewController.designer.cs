// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace geolocation_plugin.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnStartListener { get; set; }

		[Outlet]
		UIKit.UILabel lblAlt { get; set; }

		[Outlet]
		UIKit.UILabel lblHeading { get; set; }

		[Outlet]
		UIKit.UILabel lblLat { get; set; }

		[Outlet]
		UIKit.UILabel lblLong { get; set; }

		[Outlet]
		UIKit.UILabel lblSpeed { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnStartListener != null) {
				btnStartListener.Dispose ();
				btnStartListener = null;
			}

			if (lblLong != null) {
				lblLong.Dispose ();
				lblLong = null;
			}

			if (lblLat != null) {
				lblLat.Dispose ();
				lblLat = null;
			}

			if (lblAlt != null) {
				lblAlt.Dispose ();
				lblAlt = null;
			}

			if (lblHeading != null) {
				lblHeading.Dispose ();
				lblHeading = null;
			}

			if (lblSpeed != null) {
				lblSpeed.Dispose ();
				lblSpeed = null;
			}
		}
	}
}

// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TimeOfDeath.iOS
{
    [Register ("TimeTempViewController")]
    partial class TimeTempViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker dtPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBody { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSurrounds { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl segWeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper stepBodyTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper stepSurround { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem tabTimeTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWeight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (dtPicker != null) {
                dtPicker.Dispose ();
                dtPicker = null;
            }

            if (lblBody != null) {
                lblBody.Dispose ();
                lblBody = null;
            }

            if (lblSurrounds != null) {
                lblSurrounds.Dispose ();
                lblSurrounds = null;
            }

            if (segWeight != null) {
                segWeight.Dispose ();
                segWeight = null;
            }

            if (stepBodyTemp != null) {
                stepBodyTemp.Dispose ();
                stepBodyTemp = null;
            }

            if (stepSurround != null) {
                stepSurround.Dispose ();
                stepSurround = null;
            }

            if (tabTimeTemp != null) {
                tabTimeTemp.Dispose ();
                tabTimeTemp = null;
            }

            if (txtWeight != null) {
                txtWeight.Dispose ();
                txtWeight = null;
            }
        }
    }
}
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

namespace Messages.iOS.ViewControllers
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtData1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtData2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtData3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtData4 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtData1 != null) {
                txtData1.Dispose ();
                txtData1 = null;
            }

            if (txtData2 != null) {
                txtData2.Dispose ();
                txtData2 = null;
            }

            if (txtData3 != null) {
                txtData3.Dispose ();
                txtData3 = null;
            }

            if (txtData4 != null) {
                txtData4.Dispose ();
                txtData4 = null;
            }
        }
    }
}
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

namespace Movement.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnForward { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnForward != null) {
                btnForward.Dispose ();
                btnForward = null;
            }

            if (Button != null) {
                Button.Dispose ();
                Button = null;
            }
        }
    }
}
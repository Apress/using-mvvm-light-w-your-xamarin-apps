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

namespace SQLiteExample.iOS
{
    [Register ("AddHobbies")]
    partial class AddHobbies
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddToDatabase { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pckFrequency { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtHobbyName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddToDatabase != null) {
                btnAddToDatabase.Dispose ();
                btnAddToDatabase = null;
            }

            if (pckFrequency != null) {
                pckFrequency.Dispose ();
                pckFrequency = null;
            }

            if (txtCost != null) {
                txtCost.Dispose ();
                txtCost = null;
            }

            if (txtDescription != null) {
                txtDescription.Dispose ();
                txtDescription = null;
            }

            if (txtHobbyName != null) {
                txtHobbyName.Dispose ();
                txtHobbyName = null;
            }
        }
    }
}
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
    [Register ("AddPets")]
    partial class AddPets
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddToDatabase { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swchIsDog { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBreed { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPetName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddToDatabase != null) {
                btnAddToDatabase.Dispose ();
                btnAddToDatabase = null;
            }

            if (swchIsDog != null) {
                swchIsDog.Dispose ();
                swchIsDog = null;
            }

            if (txtAge != null) {
                txtAge.Dispose ();
                txtAge = null;
            }

            if (txtBreed != null) {
                txtBreed.Dispose ();
                txtBreed = null;
            }

            if (txtPetName != null) {
                txtPetName.Dispose ();
                txtPetName = null;
            }
        }
    }
}
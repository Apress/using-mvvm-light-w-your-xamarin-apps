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

namespace SQLite.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddToDB { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCurrentId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRecords { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAddressOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAddressThree { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAddressTwo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtMobile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPostcode { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddToDB != null) {
                btnAddToDB.Dispose ();
                btnAddToDB = null;
            }

            if (lblCurrentId != null) {
                lblCurrentId.Dispose ();
                lblCurrentId = null;
            }

            if (lblRecords != null) {
                lblRecords.Dispose ();
                lblRecords = null;
            }

            if (txtAddressOne != null) {
                txtAddressOne.Dispose ();
                txtAddressOne = null;
            }

            if (txtAddressThree != null) {
                txtAddressThree.Dispose ();
                txtAddressThree = null;
            }

            if (txtAddressTwo != null) {
                txtAddressTwo.Dispose ();
                txtAddressTwo = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtMobile != null) {
                txtMobile.Dispose ();
                txtMobile = null;
            }

            if (txtName != null) {
                txtName.Dispose ();
                txtName = null;
            }

            if (txtPostcode != null) {
                txtPostcode.Dispose ();
                txtPostcode = null;
            }
        }
    }
}
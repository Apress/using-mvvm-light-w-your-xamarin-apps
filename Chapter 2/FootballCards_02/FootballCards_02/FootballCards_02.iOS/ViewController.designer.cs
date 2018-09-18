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

namespace FootballCards_02.iOS
{
    [Register("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIButton btnShuffle { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel lblCapacity { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel lblStadium { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel lblTeamName { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField txtShuffles { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (btnShuffle != null)
            {
                btnShuffle.Dispose();
                btnShuffle = null;
            }

            if (lblCapacity != null)
            {
                lblCapacity.Dispose();
                lblCapacity = null;
            }

            if (lblStadium != null)
            {
                lblStadium.Dispose();
                lblStadium = null;
            }

            if (lblTeamName != null)
            {
                lblTeamName.Dispose();
                lblTeamName = null;
            }

            if (txtShuffles != null)
            {
                txtShuffles.Dispose();
                txtShuffles = null;
            }
        }
    }
}
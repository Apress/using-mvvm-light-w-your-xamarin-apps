using System;

using UIKit;
using SQLite.iOS;

namespace SQLiteExample.iOS
{
    public partial class ViewData : UIViewController
    {
        ShowDataViewModel ViewModel => AppDelegate.Locator.ShowDataVM;

        public ViewData(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


using Android.App;
using Android.OS;
using geolocation_plugin.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using Plugin.Permissions;
using Android.Content.PM;
using Android;
using Android.Support.V4.Content;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using System;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;

namespace geolocation_plugin.Droid
{
    [Activity(Label = "geolocation_plugin", MainLauncher = true)]
    public partial class MainActivity : Activity
    {
        MainViewModel ViewModel => App.Locator.Main;

        static readonly int REQUEST_LOCATIONS = 0;
        static string[] PERMISSIONS_LOCATION = { Manifest.Permission_group.Location };

        View layout;

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            layout = FindViewById<LinearLayout>(Resource.Id.main_layout);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                RequestLocationPermission();

            BindTextViews();
            BindButton();
        }

        void RequestLocationPermission()
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission_group.Location) != Permission.Granted)
                {
                    if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission_group.Location))
                    {
                        RunOnUiThread(() =>
                        {
                            Snackbar.Make(layout, "Location access is required for this app.", Snackbar.LengthIndefinite)
                                    .SetAction("OK", v => RequestPermissions(PERMISSIONS_LOCATION, REQUEST_LOCATIONS)).Show();
                            return;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex = {ex.Message}");
            }
        }

        void BindTextViews()
        {
            this.SetBinding(
                () => ViewModel.Altitude,
                () => TxtAlt.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Heading,
                () => TxtHeading.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Latitude,
                () => TxtLat.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Longitude,
                () => TxtLong.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Speed,
                () => TxtSpeed.Text,
                BindingMode.TwoWay);
        }

        void BindButton()
        {
            BtnListen.SetCommand("Click", ViewModel.BtnStart);
        }
    }
}


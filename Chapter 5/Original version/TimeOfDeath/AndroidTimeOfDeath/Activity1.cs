using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace AndroidTimeOfDeath
{

    public static class common
    {
        public static int setP
        { get; set; }

        public static int setA
        { get; set; }

        public static int setW
        { get; set; }

        public static int setPA
        { get; set; }

        public static double bodyWeight
        { get; set; }

        public static double tempBody
        { get; set; }

        public static double tempSurround
        { get; set; }

        public static string timeOfDeath
        { get; set; }

        public static string dateOfDeath
        { get; set; }

        public static DateTime date
        { get; set; }
    }

    public class calculator : Activity
    {
        private double[,] correctionData = new double[3, 20];
        private double[,] iterations = new double[3, 20];
        private double c = 0, b = 0, cas = 0;

        private double correctionFactor()
        {
            double correction = 0;
            switch (common.setP)
            {
                case 0: // dry naked
                    correction = common.setA == 0 ? 0.75 : 1;
                    break;
                case 1: // dry 1-2 thin layers
                    correction = common.setA == 0 ? 0.9 : 1.1;
                    break;
                case 2: // dry 2-3 thin layers
                case 4: // dry 1-2 thicker
                    correction = 1.2;
                    break;
                case 3: // dry 3-4 thin layers
                    correction = 1.3;
                    break;
                case 5: // more layers
                    correction = common.setA == 2 ? 1.8 : 1.4;
                    break;
                case 6: // naked
                    if (common.setW != 2 && common.setA == -2)
                        correction = common.setW == 0 ? 0.35 : 0.5;
                    else
                        correction = 0.7;
                    break;
                case 7: // wet 1-2 thin layers
                    correction = 0.7;
                    break;
                case 8: // wet 2 thicker
                    correction = 1.1;
                    break;
                case 9: // wet, 2 or more
                    correction = common.setPA == 0 ? 1.2 : 0.9;
                    break;
            }
            return correction;
        }

        private void calculateCandB(double ta, double tr, double m)
        {
            c = (tr - ta) / (37.2 - ta);
            b = -1.2815 * (1 / Math.Pow(m, 0.625)) + 0.0284;
        }

        private void calculateCorrections(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 6.25 : 11;
            double z = test == true ? 5 : 10;
            int n = 1;
            correctionData[0, 0] = 0;
            correctionData[1, 0] = x * (b * b) * Math.Exp(b * correctionData[0, 0]) -
            y * (b * b) * Math.Exp(z * b * correctionData[0, 0]);
            correctionData[2, 0] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, 0]) -
            y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, 0]);
            while (n < 20)
            {
                correctionData[0, n] = correctionData[0, n - 1] -
                (correctionData[1, n - 1] / correctionData[2, n - 1]);
                correctionData[1, n] = x * (b * b) * Math.Exp(b * correctionData[0, n]) -
                y * (b * b) * Math.Exp(z * b * correctionData[0, n]);
                correctionData[2, n] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, n]) -
                y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, n]);
                n++;
            }
        }

        private void calculateIterations(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 0.25 : 0.11;
            double z = test == true ? 5 : 10;
            double o = test == true ? 6.25 : 11;
            double j = x * (b * b) * Math.Exp(b * (correctionData[0, 19] + 0.0001)) - o * (b * b) *
                       Math.Exp(z * b * (correctionData[0, 19] + 0.0001));
            double n = x * Math.Exp(b * (correctionData[0, 19] + 0.0001)) -
                       y * Math.Exp(z * b * (correctionData[0, 19] + 0.0001)) - c;
            double g = x * (b * b) * Math.Exp(b * (correctionData[0, 19] - 0.0001)) -
                       o * (b * b) * Math.Exp(z * b * (correctionData[0, 19] - 0.0001));
            double h = x * Math.Exp(b * (correctionData[0, 19] - 0.0001)) -
                       y * Math.Exp(z * b * (correctionData[0, 19] - 0.0001)) - c;
            double f = j * n;
            double i = g * h;

            int q = 0;
            if (f > 0)
                iterations[0, q] = correctionData[0, 19] + 0.0001;
            else if (g > 0)
                iterations[0, q] = correctionData[0, 19] - 0.0001;
            else
                iterations[0, q] = 999.9999; // it's in here for a hack!
            while (q < 20)
            {
                if (q > 0)
                    iterations[0, q] = iterations[0, q - 1] - (iterations[1, q - 1] / iterations[2, q - 1]);
                iterations[1, q] = x * Math.Exp(b * iterations[0, q]) -
                y * Math.Exp(z * b * iterations[0, q]) - c;
                iterations[2, q] = x * b * Math.Exp(b * iterations[0, q]) -
                x * b * Math.Exp(z * b * iterations[0, q]);
                q++;
            }

            if (iterations[1, 19] < 0.00000001)
                cas = iterations[0, 19];
        }

        public void calcTOD(DateTime death)
        {
            DateTime newdeath;
            double ta = common.tempSurround;
            double tr = common.tempBody;
            double m = common.bodyWeight;
            double factor;
            bool t = ta <= 23 ? true : false;
            calculateCandB(ta, tr, m);
            calculateCorrections(t);
            calculateIterations(t);
            factor = correctionFactor();
            double h, mi;
            h = (-cas * factor); // convert to minutes
            mi = -(((cas - Convert.ToInt32(cas)) * 100) / 1.6666) * factor + h;
            newdeath = death.AddHours(h).AddMinutes(mi);
            TimeSpan calced = death.Subtract(newdeath);
            DateTime todead = death.Subtract(calced);
            common.timeOfDeath = todead.ToShortTimeString();
            common.dateOfDeath = todead.Date.ToShortDateString();
        }
    }

    class DateChangedListener : Java.Lang.Object, DatePicker.IOnDateChangedListener
    {
        Action<DatePicker, int, int, int> callback;

        public DateChangedListener(Action<DatePicker, int, int, int> callback)
        {
            this.callback = callback;
        }

        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            callback(view, year, monthOfYear, dayOfMonth);
        }
    }

    [Activity]
    public class TimeTemp : Activity
    {
        DateTime today;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.datepicker3);
            today = DateTime.Now;
            EditText surround = FindViewById<EditText>(Resource.Id.tempSurround);
            surround.TextChanged += new EventHandler<Android.Text.TextChangedEventArgs>(alterValue);

            EditText body = FindViewById<EditText>(Resource.Id.tempBody);
            body.TextChanged += new EventHandler<Android.Text.TextChangedEventArgs>(alterValue);

            EditText bweight = FindViewById<EditText>(Resource.Id.weightBody);
            bweight.TextChanged += new EventHandler<Android.Text.TextChangedEventArgs>(alterValue);

            TimePicker timeFound = FindViewById<TimePicker>(Resource.Id.timeFound);
            timeFound.SetIs24HourView(Java.Lang.Boolean.True);
            timeFound.TimeChanged += new EventHandler<TimePicker.TimeChangedEventArgs>(alterTime);

            DatePicker dater = FindViewById<DatePicker>(Resource.Id.dateDisplay);
            int monthFix = today.Month - 1;
            dater.Init(today.Year, monthFix, today.Day, new DateChangedListener((DatePicker, year, month, day) =>
                    {
                        DateTime c = common.date;
                        DateTime d = new DateTime(year, month + 1, day, c.Hour, c.Minute, 0); // fix as Android goes from 0 - 11 whereas .NET goes 1 - 12
                        common.date = d;
                    }));

            CheckBox weight = FindViewById<CheckBox>(Resource.Id.weightBodyKG);
            weight.CheckedChange += new EventHandler<Android.Widget.CompoundButton.CheckedChangeEventArgs>(convertUnits);
        }

        private void alterTime(object sender, TimePicker.TimeChangedEventArgs e)
        {
            DateTime to = common.date;
            DateTime t = new DateTime(to.Year, to.Month, to.Day, e.HourOfDay, e.Minute, 0);
            common.date = t;
        }

        private void alterValue(object sender, EventArgs e)
        {
            EditText et = (EditText)sender;
            if (et.Text != "")
            {
                switch (et.Id)
                {
                    case Resource.Id.weightBody:
                        common.bodyWeight = Convert.ToDouble(et.Text);
                        break;
                    case Resource.Id.tempBody:
                        common.tempBody = Convert.ToDouble(et.Text);
                        break;
                    case Resource.Id.tempSurround:
                        common.tempSurround = Convert.ToDouble(et.Text);
                        break;
                }
            }
        }

        private void convertUnits(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            EditText et = FindViewById<EditText>(Resource.Id.weightBody);
            if (et.Text != "")
            {
                double ow = Convert.ToDouble(et.Text);
                if (ow != 0)
                    common.bodyWeight = cb.Checked == false ? ow * 6.35029318 : ow;
                else
                    cb.Checked = true;
            }
        }
    }

    [Activity]
    public class StateFound : Activity/*, ITabs*/
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.conditions);
            // set up each spinner
            Spinner bodyCondSpinner = FindViewById<Spinner>(Resource.Id.bodyCondSpinner);
            bodyCondSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerSelected);
            var adapterBCS = ArrayAdapter.CreateFromResource(this, Resource.Array.condition, Android.Resource.Layout.SimpleSpinnerItem);
            adapterBCS.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            bodyCondSpinner.Adapter = adapterBCS;
            //
            Spinner foundAirSpinner = FindViewById<Spinner>(Resource.Id.foundAirSpinner);
            foundAirSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerSelected);
            var adapterFAS = ArrayAdapter.CreateFromResource(this, Resource.Array.inair, Android.Resource.Layout.SimpleSpinnerItem);
            adapterFAS.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            foundAirSpinner.Adapter = adapterFAS;
            //
            Spinner foundWaterSpinner = FindViewById<Spinner>(Resource.Id.foundWaterSpinner);
            foundWaterSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerSelected);
            foundWaterSpinner.Enabled = false;
            var adapterFWS = ArrayAdapter.CreateFromResource(this, Resource.Array.inwater, Android.Resource.Layout.SimpleSpinnerItem);
            adapterFWS.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            foundWaterSpinner.Adapter = adapterFWS;
            //
            Spinner fromWaterSpinner = FindViewById<Spinner>(Resource.Id.fromWaterSpinner);
            fromWaterSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerSelected);
            fromWaterSpinner.Enabled = false;
            var adapterOWS = ArrayAdapter.CreateFromResource(this, Resource.Array.outwater, Android.Resource.Layout.SimpleSpinnerItem);
            adapterOWS.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            fromWaterSpinner.Adapter = adapterOWS;

            Button calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += new EventHandler(calculateTOD);
        }

        private void calculateTOD(object sender, EventArgs e)
        {
            if (getTab1() == true)
                return;
            getTab2();
            var ta = IsChild ? Parent as TabActivity : null;
            if (ta != null)
                ta.TabHost.CurrentTab = 2;
        }

        public bool getTab1()
        {
            if (common.tempSurround == -999)
            {
                errorMessage("Temp of surround = null");
                return true;
            }
            if (common.tempBody == -999)
            {
                errorMessage("Temp of body = null");
                return true;
            }
            if (common.tempBody < common.tempSurround)
            {
                errorMessage("Body temperature must be greater than surrounds");
                return true;
            }
            if (common.bodyWeight <= 0)
            {
                errorMessage("The body has to have some weight");
                return true;
            }
            return false;
        }

        private void errorMessage(string f)
        {
            Toast.MakeText(this, f, ToastLength.Short).Show();
        }

        public void getTab2()
        {
            calculator calc = new calculator();
            calc.calcTOD(common.date);
        }

        private void spinnerSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            Spinner air = FindViewById<Spinner>(Resource.Id.foundAirSpinner);
            Spinner iwater = FindViewById<Spinner>(Resource.Id.foundWaterSpinner);
            Spinner fwater = FindViewById<Spinner>(Resource.Id.fromWaterSpinner);
            Spinner body = FindViewById<Spinner>(Resource.Id.bodyCondSpinner);
            switch (spinner.Id)
            {
                case Resource.Id.bodyCondSpinner:
                    {
                        if (spinner.GetItemIdAtPosition(e.Position) >= 6)
                        {
                            common.setW = 1;
                            common.setA = -2;
                            iwater.Enabled = true;
                            air.Enabled = false;
                        }
                        else
                        {
                            common.setW = 0;
                            iwater.Enabled = false;
                            air.Enabled = true;
                        }
                    }
                    common.setP = Convert.ToInt32(spinner.GetItemIdAtPosition(e.Position));
                    break;
                case Resource.Id.foundAirSpinner:
                    common.setA = Convert.ToInt32(air.GetItemIdAtPosition(e.Position));
                    common.setPA = common.setW = -1;
                    break;
                case Resource.Id.foundWaterSpinner:
                    if (spinner.GetItemIdAtPosition(e.Position) == 2)
                    {
                        fwater.Enabled = true;
                        common.setPA = 0;
                    }
                    else
                        fwater.Enabled = false;
                    common.setA = -2;
                    common.setW = Convert.ToInt32(iwater.GetItemIdAtPosition(e.Position));
                    break;
                case Resource.Id.fromWaterSpinner:
                    common.setA = -2;
                    common.setPA = Convert.ToInt32(fwater.GetItemIdAtPosition(e.Position));
                    break;
            }
        }
    }

    [Activity]
    public class Results : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.results);
            TextView timeDeath = FindViewById<TextView>(Resource.Id.timeResults);
            TextView dateDeath = FindViewById<TextView>(Resource.Id.dateResults);
            timeDeath.Text = common.timeOfDeath;
            dateDeath.Text = common.dateOfDeath;
        }
    }

    [Activity]
    public class Information : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.information);
            Button closeButton = FindViewById<Button>(Resource.Id.close);
            closeButton.Click += new EventHandler(closeInfo);
        }

        private void closeInfo(object sender, EventArgs e)
        {
            Finish();
        }
    }

    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/tod_large")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(AndroidTimeOfDeath));
        }
    }

    [Activity(/*MainLauncher = true, Label = "@string/ApplicationName",*/ Theme = "@android:style/Theme.NoTitleBar")]
    public class AndroidTimeOfDeath : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            TabHost.TabSpec spec;
            Intent intent;
            intent = new Intent(this, typeof(TimeTemp));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("timedate");
            spec.SetIndicator("Basic Info", Resources.GetDrawable(Resource.Drawable.ic_tab_weather));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            intent = new Intent(this, typeof(StateFound));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("conditions");
            spec.SetIndicator("Conditions", Resources.GetDrawable(Resource.Drawable.ic_tab_conditions));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            intent = new Intent(this, typeof(Results));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("results");
            spec.SetIndicator("Results", Resources.GetDrawable(Resource.Drawable.ic_tab_dead));
            spec.SetContent(intent);
            TabHost.AddTab(spec);

            TabHost.CurrentTab = 0;
            common.tempBody = common.tempSurround = -999;
            common.setA = common.setP = common.setPA = common.setW = 0;
            common.date = DateTime.Now;
            common.timeOfDeath = DateTime.Now.ToShortTimeString();
            common.dateOfDeath = DateTime.Now.ToShortDateString();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var menuItem1 = menu.Add(0, 1, 1, Resource.String.Copyright);
            var menuItem2 = menu.Add(0, 2, 2, Resource.String.Close);
            menuItem1.SetIcon(Resource.Drawable.exclaim);
            menuItem2.SetIcon(Resource.Drawable.close);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case 1:
                    Intent intentCopy = new Intent(this, typeof(Information));
                    intentCopy.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intentCopy);
                    break;
                case 2:
                    System.Environment.Exit(-1);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
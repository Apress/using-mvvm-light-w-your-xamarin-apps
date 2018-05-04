using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;

namespace SQLiteExample.Droid
{
    public class ListViewAdapter : BaseAdapter<PersonalInfo>
    {
        Activity context;
        public List<PersonalInfo> data;
        ShowDataViewModel ViewModel;

        public ListViewAdapter(Activity c, List<PersonalInfo> dta, ShowDataViewModel vm) : base()
        {
            context = c;
            data = dta;
            ViewModel = vm;
        }

        public override int Count
        {
            get
            {
                return data == null ? 0 : data.Count;
            }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override PersonalInfo this[int position]
        {
            get
            {
                return data[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            var item = data[position];

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListData, parent, false);
                var id = view.FindViewById<TextView>(Resource.Id.txtID);
                var name = view.FindViewById<TextView>(Resource.Id.txtName);
                var address = view.FindViewById<TextView>(Resource.Id.txtAddress);
                var email = view.FindViewById<TextView>(Resource.Id.txtEmail);
                var mobile = view.FindViewById<TextView>(Resource.Id.txtMobile);
                var pets = view.FindViewById<Switch>(Resource.Id.swchPets);
                var hobbies = view.FindViewById<Switch>(Resource.Id.swchHobbies);
                pets.Enabled = hobbies.Enabled = false;

                id.Text = item.id.ToString();
                name.Text = item.Name;
                address.Text = item.AddressLineOne;
                email.Text = item.EmailAddress;
                mobile.Text = item.MobilePhone;

                ViewModel.ParentId = item.id;
                this.SetBinding(
                    () => ViewModel.GetHasPet,
                    () => pets.Checked,
                    BindingMode.TwoWay);

                this.SetBinding(
                    () => ViewModel.GetHasHobbies,
                    () => hobbies.Checked,
                    BindingMode.TwoWay);
            }

            return view;
        }
    }
}

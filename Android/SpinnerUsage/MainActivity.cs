using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace SpinnerUsage
{
    // Reference at:
    // https://developer.xamarin.com/guides/android/user_interface/spinner/

    [Activity(Label = "SpinnerUsage", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Spinner spn1;
        private Spinner spn2;
        private Spinner spn3;
        private Button btn;

        #region Spinner Items
        private string[] items = {
                "No.1",
                "No.2",
                "No.3",
                "No.4",
                "No.5",
                "No.6",
                "No.7",
                "No.8",
                "No.9",
                "No.10",
                "No.11",
                "No.12",
                "No.13",
                "No.14",
                "No.15",
                "No.16",
                "No.17",
                "No.18",
                "No.19",
                "No.20",
            };
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            this.spn1 = this.FindViewById<Spinner>(Resource.Id.spinner1);
            this.spn2 = this.FindViewById<Spinner>(Resource.Id.spinner2);
            this.spn3 = this.FindViewById<Spinner>(Resource.Id.spinner3);
            this.btn = this.FindViewById<Button>(Resource.Id.button1);

            this.SetSpinnerItemsByResource();
            this.SetSpinnerItemsByArray();
        }

        private void SetSpinnerItemsByResource()
        {
            var adapter = ArrayAdapter.CreateFromResource(
                this,
                Resource.Array.SpinnerEntries,
                Android.Resource.Layout.SimpleSpinnerDropDownItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            this.spn2.Adapter = adapter;
        }

        private void SetSpinnerItemsByArray()
        {
            var adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleSpinnerItem,
                this.items);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            this.spn3.Adapter = adapter;
        }

        protected override void OnResume()
        {
            base.OnResume();

            this.spn1.ItemSelected += this.spinner1_ItemSelected;
            this.spn2.ItemSelected += this.spinner_ItemSelected;
            this.spn3.ItemSelected += this.spinner_ItemSelected;
            this.btn.Click += this.button1_Click;
        }

        protected override void OnPause()
        {
            this.spn1.ItemSelected -= this.spinner1_ItemSelected;
            this.spn2.ItemSelected -= this.spinner_ItemSelected;
            this.spn3.ItemSelected -= this.spinner_ItemSelected;
            this.btn.Click -= this.button1_Click;

            base.OnPause();
        }

        private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var item = this.spn1.SelectedItem.ToString();

            this.btn.Text = item;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spn = sender as Spinner;
            var item = spn?.SelectedItem.ToString();

            this.btn.Text = item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = this.btn.Text;
            this.SelectSpinnerItem(this.spn1, item);
            this.SelectSpinnerItem(this.spn2, item);
            this.SelectSpinnerItem(this.spn3, item);
        }

        private void SelectSpinnerItem(Spinner spinner, string selectionItem)
        {
            if (spinner.SelectedItem.ToString() == selectionItem)
            {
                return;
            }

            var adp = spinner.Adapter;
            for (var i = 0; i < adp.Count; i++)
            {
                string item = adp.GetItem(i).ToString();
                if (selectionItem == item)
                {
                    spinner.SetSelection(i);
                    break;
                }
            }
        }
    }
}


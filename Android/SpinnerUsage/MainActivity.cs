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
        private Button btn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            this.spn1 = this.FindViewById<Spinner>(Resource.Id.spinner1);
            this.spn2 = this.FindViewById<Spinner>(Resource.Id.spinner2);
            this.btn = this.FindViewById<Button>(Resource.Id.button1);
        }

        protected override void OnResume()
        {
            base.OnResume();

            this.spn1.ItemSelected += this.spinner1_ItemSelected;
            this.spn2.ItemSelected += this.spinner2_ItemSelected;
            this.btn.Click += this.button1_Click;
        }

        protected override void OnPause()
        {
            this.spn1.ItemSelected -= this.spinner1_ItemSelected;
            this.spn2.ItemSelected -= this.spinner2_ItemSelected;
            this.btn.Click -= this.button1_Click;

            base.OnPause();
        }

        private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var item = this.spn1.SelectedItem.ToString();

            this.btn.Text = item;
        }

        private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentUsage
{
    public class MainFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.Main, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var btn1 = this.Activity.FindViewById<Button>(Resource.Id.button1);
            btn1.Click += button1_OnClicked;

            var btn2 = this.Activity.FindViewById<Button>(Resource.Id.button2);
            btn2.Click += button2_OnClicked;

            var btn3 = this.Activity.FindViewById<Button>(Resource.Id.button3);
            btn3.Click += button3_OnClicked;
        }

        private void button1_OnClicked(object sender, EventArgs e)
        {
            //var manager = this.FragmentManager;
            //var trans = manager.BeginTransaction();
            //trans.Replace(Android.Resource.Id.Content, new Fragment1());
            //trans.AddToBackStack(null);
            //trans.Commit();

            // can use method chain
            this.FragmentManager
                .BeginTransaction()
                .Replace(Android.Resource.Id.Content, new Fragment1())
                .AddToBackStack(null)
                .Commit();
        }

        private void button2_OnClicked(object sender, EventArgs e)
        {
            this.FragmentManager
                .BeginTransaction()
                .Add(Resource.Id.linearLayout1, new Fragment1())
                .Add(Resource.Id.linearLayout1, new Fragment2())
                .Add(Resource.Id.linearLayout1, new Fragment1())
                .Add(Resource.Id.linearLayout1, new Fragment2())
                .AddToBackStack(null)
                .Commit();
        }

        private void button3_OnClicked(object sender, EventArgs e)
        {
            var intent = new Intent(this.Activity, typeof(Activity1));
            this.StartActivity(intent);
        }
    }
}
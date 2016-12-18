using Android.App;
using Android.Widget;
using Android.OS;

namespace FragmentUsage
{
    [Activity(Label = "FragmentUsage", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.FragmentManager
                .BeginTransaction()
                .Replace(Android.Resource.Id.Content, new MainFragment())
                .Commit();
        }
    }
}


using Android.App;
using Android.Widget;
using Android.OS;

namespace ScreenOrientationUsage
{
    [Activity(Label = "ScreenOrientationUsage", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Add `android:configChanges="orientation|screenSize"` in Main.axml
        }
    }
}


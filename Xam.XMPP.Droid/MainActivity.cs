using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xam.XMMP;
using Acr.UserDialogs;

namespace Xam.XMPP.Droid
{
    [Activity(Label = "Xam.XMPP.Droid", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;

            base.OnCreate(savedInstanceState);

            UserDialogs.Init(this);
            Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
    }
}


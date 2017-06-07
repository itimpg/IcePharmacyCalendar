
using Android.App;
using Android.Content.PM;
using Android.OS;
using PCalendar.Services;
using PCalendar.Services.Interfaces;
using TinyIoC;

namespace PCalendar.Droid
{
    [Activity(Label = "PCalendar", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            TinyIoCContainer.Current.Register<ISQLiteDb, SQLiteDb>();
            TinyIoCContainer.Current.Register<IScheduleService, ScheduleService>();

            LoadApplication(new PCalendar.App());
        }
    }
}


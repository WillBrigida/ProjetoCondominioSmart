using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;

namespace ProjetoCondominioSmart.Droid
{
    [Activity(
        Label = "ProjetoCondominioSmart", 
        Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("android=d1466097-4979-46a5-aba1-9ee42a8ccb6b;",
              typeof(Analytics), typeof(Crashes));

            try
            {

                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

                //var alarmIntent = new Intent(this, typeof(Alarm));
                //alarmIntent.PutExtra("title", "MainActtivity");
                //alarmIntent.PutExtra("message", "Teste");
                //alarmIntent.SetFlags(ActivityFlags.IncludeStoppedPackages);
                //PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 1, alarmIntent, PendingIntentFlags.UpdateCurrent);
                //AlarmManager alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();

                ////AlarmType.RtcWakeup – it will fire up the pending intent at a specified time, waking up the device
                //alarmManager.SetRepeating(AlarmType.RtcWakeup, Java.Lang.JavaSystem.CurrentTimeMillis(), 60000, pendingIntent);
                //PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, alarmIntent, 0);


                LoadApplication(new App(new AndroidInitializer()));
            }
            catch (System.Exception e)
            {
                Analytics.TrackEvent("OnCreate", new Dictionary<string, string>
                {
                    { "Erro", e.Message },
                });
            }
           


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
         {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                //Debug.WriteLine("Android back button: There are not any pages in the PopupStack");
            }
        }
    }
}
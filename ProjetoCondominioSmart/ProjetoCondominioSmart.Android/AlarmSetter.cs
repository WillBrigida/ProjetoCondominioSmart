using Android.App;
using Android.Content;
using Java.Util.Prefs;
using Microsoft.AppCenter.Analytics;
using ProjetoCondominioSmart.Droid;
using ProjetoCondominioSmart.Models;
using ProjetoCondominioSmart.Others;
using ProjetoCondominioSmart.Others.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AlarmSetter))]

namespace ProjetoCondominioSmart.Droid
{
    public class AlarmSetter : IAlarmSetter
    {
        Repository<Scheduling> _repositoryScheduling;

        public static long reminderInterval = 60 * 1000;

        AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));


        public void SetAlarm(Scheduling scheduling, int intMinute)
        {
            try
            {
                Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
                calendar.Set(Java.Util.CalendarField.HourOfDay, scheduling.Hour);
                calendar.Set(Java.Util.CalendarField.Minute, scheduling.Minute);
                calendar.Set(Java.Util.CalendarField.Second, 0);

                alarmIntent.PutExtra("title", scheduling.Title);
                alarmIntent.PutExtra("message", scheduling.Massage);
                alarmIntent.SetFlags(ActivityFlags.IncludeStoppedPackages);
                var pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

                bool isWorking = (PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent,
                   PendingIntentFlags.NoCreate) != null);


                //alarmManager.SetRepeating(AlarmType.RtcWakeup, calendar.TimeInMillis - intMinute * 60000, AlarmManager.IntervalFifteenMinutes, pendingIntent);
                alarmManager.SetRepeating(AlarmType.RtcWakeup, Java.Lang.JavaSystem.CurrentTimeMillis(), 60000, pendingIntent);

                _repositoryScheduling = new Repository<Scheduling>();
                var a = _repositoryScheduling.GetAll().FirstOrDefault();
            }

            catch (System.Exception e)
            {

                Analytics.TrackEvent("SetAlarm", new Dictionary<string, string>
                {
                    { "Erro", e.Message },
                });
            }
        }
        public void SetAlarm()
        {
        //    try
        //    {

          
        //    var alarmIntent = new Intent(Forms.Context, typeof(Alarm));
        //    alarmIntent.PutExtra("title", "Reinicio");
        //    alarmIntent.PutExtra("message", "Mensagem");

        //    bool isWorking = (PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent,
        //     PendingIntentFlags.NoCreate) != null);
        //    if (!isWorking)
        //    {
        //        var pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 1, alarmIntent, PendingIntentFlags.UpdateCurrent);
        //        alarmManager.SetRepeating(AlarmType.RtcWakeup, Java.Lang.JavaSystem.CurrentTimeMillis(), AlarmManager.IntervalFifteenMinutes, pendingIntent);
        //    }
        //    }
        //    catch (System.Exception e)
        //    {

        //        Analytics.TrackEvent("SetAlarm 2", new Dictionary<string, string>
        //        {
        //            { "Erro", e.Message },
        //        });
        //    }
        }

        public void DeleteAlarm()
        {
            alarmIntent.SetFlags(ActivityFlags.IncludeStoppedPackages);
            var pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            alarmManager.Cancel(pendingIntent);
        }
    }
}
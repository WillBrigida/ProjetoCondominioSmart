﻿using Android.App;
using Android.Content;
using Android.Support.V4.App;

namespace ProjetoCondominioSmart.Droid
{
    [BroadcastReceiver]

    public class AlarmReceiver : BroadcastReceiver
    {
        //Classe que gerencia o envio das notificações
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var resultIntent = new Intent(context, typeof(AlarmReceiver));
            var pending = PendingIntent.GetActivity(context, 0, resultIntent, PendingIntentFlags.CancelCurrent);
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            var builder = new Notification.Builder(context)
                .SetDefaults(NotificationDefaults.Sound)
                .SetContentIntent(pending)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.plugin_lc_smallicon)
                .SetContentText(message)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetAutoCancel(true);

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(0, notification);
        }
    }
}
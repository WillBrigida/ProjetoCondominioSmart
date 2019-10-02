using ProjetoCondominioSmart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCondominioSmart.Others.Services
{
    public interface IAlarmSetter
    {
        void DeleteAlarm();
        void SetAlarm(Scheduling horaAgendada, int minuto);
        void SetAlarm();
    }
}

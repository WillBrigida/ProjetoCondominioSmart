using Plugin.LocalNotifications;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ProjetoCondominioSmart.Models;
using ProjetoCondominioSmart.Others;
using ProjetoCondominioSmart.Others.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetoCondominioSmart.ViewModels
{
    public class TesteViewModel : BaseViewModel
    {
         Repository<Scheduling> _repositoryScheduling;
        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    ScheduleNotification(Minutes[_selectedIndex].IntMinute);
                }
                SetProperty(ref _selectedIndex, value);
            }
        }


        public ObservableCollection<MinuteList> Minutes { get; set; }
        protected TesteViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService, pageDialogService)
        {
            Minutes = new ObservableCollection<MinuteList>();
            OnGetMinutes();
            SelectedIndex = 0;
        }

        private void Init()
        {
            Xamarin.Forms.DependencyService.Get<IAlarmSetter>().SetAlarm();
        }

        private void OnGetMinutes()
        {
            var minutes = new List<MinuteList>
            {
                new MinuteList{IntMinute = 0, StrMinute = "0 Minute Before"},
                new MinuteList{IntMinute = 1, StrMinute = "1 Minute Before"},
                new MinuteList{IntMinute = 5, StrMinute = "5 Minutes Before"},
                new MinuteList{IntMinute = 10, StrMinute = "10 Minutes Before"},
                new MinuteList{IntMinute = 15, StrMinute = "15 Minutes Before"},
                new MinuteList{IntMinute = 30, StrMinute = "30 Minutes Before"},
                new MinuteList{IntMinute = 45, StrMinute = "45 Minutes Before"},
            };

            foreach (var minute in minutes)
                Minutes.Add(minute);
        }

        public DelegateCommand TestePopupPageCommand => new DelegateCommand(async () => await OnTestePopupPage());
        public DelegateCommand TesteCancelarNotificacaoCommand => new DelegateCommand(async () => await OnCancelarNotificacao());





        private void ScheduleNotification(int intMinutes)
        {

            if (intMinutes == 0) return;

            var scheduling = new Scheduling()
            {
                Title = "Snooz",
                Massage = $"Hora de Dormir {DateTime.Now}",
                Hour = 13,
                Minute = 30
            };

            _repositoryScheduling = new Repository<Scheduling>();
            _repositoryScheduling.Insert(new Scheduling {Id = 0, Hour = 18, Minute = 00, Massage = $"Hora de Dormir {DateTime.Now}", Title = "Snooz"});

            Xamarin.Forms.DependencyService.Get<IAlarmSetter>().SetAlarm(scheduling, intMinutes);
        }

        private async Task OnCancelarNotificacao()
        {
            Xamarin.Forms.DependencyService.Get<IAlarmSetter>().DeleteAlarm();
        }




        private async Task OnTestePopupPage()
        {
            await NavigationService.NavigateAsync("TestePopupPage");
        }
    }
}

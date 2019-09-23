using Newtonsoft.Json;
using Plugin.LocalNotifications;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ProjetoCondominioSmart.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCondominioSmart.ViewModels
{
    public class TesteViewModel : BaseViewModel
    {
        private const string URL = "https://onesignal.com/api/v1/notifications";
        private const string APP_ID = "5bd3b9d2-1a0c-417d-89d1-3a3d9fb10cfc";
        private const string REST_API_KEY = "NzNlN2FiOTgtODBjYS00ZmNjLWE2OTktMGYyYzJmMjJhNTI2";

        private static HttpClient _client = new HttpClient();
        public static string idDelete = string.Empty;

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;

                     Agendamento(ListMinutes[_selectedIndex].IntMinutes, "Snooz", "Hora de Dormir");
                }
                SetProperty(ref _selectedIndex, value);
            }
        }

        private async Task Agendamento(int intMinutes, string title, string message)
        {
            if (intMinutes == 0) return;
           
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", REST_API_KEY);

            //var agendamento = DateTime.Now.AddMinutes(intMinutes).ToString("yyyy-MM-dd HH:mm:00");
            var agendamento = DateTime.Now.AddMinutes(intMinutes).ToString("HH:mm");

            var teste = DateTime.Now.AddMinutes(-5);


            Agenda post = new Agenda()
            {
                AppId = APP_ID,
                Contents = new Contents { En = title },
                Headings = new Contents { En = message },
                IncludedSegments = new string[] { "All" },
                //SendAfter = agendamento + " GMT-0300",
                DelayedOption = "timezone",
                DeliveryTimeOfDay = agendamento
            };

            try
            {
                var json = JsonConvert.SerializeObject(post);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = await _client.PostAsync(URL, content);
                var response = await request.Content.ReadAsStringAsync();
                var a = JsonConvert.DeserializeObject<ResponseAgendamento>(response);

                idDelete = a.Id;

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "Ok");
            }

        }

        public ObservableCollection<Minutes> ListMinutes { get; set; }
        protected TesteViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService, pageDialogService)
        {
            ListMinutes = new ObservableCollection<Minutes>();
            OnGetMinutes();
            SelectedIndex = 0;
        }

        private void OnGetMinutes()
        {
            var lista = new List<Minutes>
            {
                new Minutes{IntMinutes = 0, StringMinutes = "0 Minute Before"},
                new Minutes{IntMinutes = 1, StringMinutes = "1 Minute Before"},
                new Minutes{IntMinutes = 5, StringMinutes = "5 Minutes Before"},
                new Minutes{IntMinutes = 10, StringMinutes = "10 Minutes Before"},
                new Minutes{IntMinutes = 15, StringMinutes = "15 Minutes Before"},
                new Minutes{IntMinutes = 30, StringMinutes = "30 Minutes Before"},
                new Minutes{IntMinutes = 45, StringMinutes = "45 Minutes Before"},
            };

            foreach (var item in lista)
                ListMinutes.Add(item);
        }

        public DelegateCommand TestePopupPageCommand => new DelegateCommand(async () => await OnTestePopupPage());
        public DelegateCommand TesteNotificacaoCommand => new DelegateCommand(async () => await OnTesteNotificacao());
        public DelegateCommand TesteCancelarNotificacaoCommand => new DelegateCommand(async () => await OnTesteCancelarNotificacao());

        private async Task OnTesteNotificacao()
        {
            //Notificação Local
            CrossLocalNotifications.Current.Show("title", "body", 1, DateTime.Now.AddSeconds(5));
        }

        private async Task OnTestePopupPage()
        {
            await NavigationService.NavigateAsync("TestePopupPage");
        }

        private async Task OnTesteCancelarNotificacao()
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", REST_API_KEY);

            try
            {
                var request = await _client.DeleteAsync($"{URL}/{idDelete}?app_id={APP_ID}");
                var response = await request.Content.ReadAsStringAsync();
                await PageDialogService.DisplayAlertAsync("Resposta", response, "OK");
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "Ok");
            }
        }
    }
}

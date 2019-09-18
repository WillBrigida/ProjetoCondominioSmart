using Plugin.LocalNotifications;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ProjetoCondominioSmart.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProjetoCondominioSmart.ViewModels
{
    public class TesteViewModel : BaseViewModel
    {

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    CrossLocalNotifications.Current.Show("title", "body", 1, DateTime.Now.AddSeconds(ListMinutes[_selectedIndex].IntMinutes));
                }
                SetProperty(ref _selectedIndex, value);
            }
        }


        public ObservableCollection<Minutes> ListMinutes { get; set; }
        protected TesteViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService, pageDialogService)
        {
            ListMinutes = new ObservableCollection<Minutes>();
            OnGetMinutes();
        }

        private void OnGetMinutes()
        {
            var lista = new List<Minutes>
            {
                new Minutes{IntMinutes = 0, StringMinutes = "0 Minute Before"},
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

        private async Task OnTesteNotificacao()
        {
            CrossLocalNotifications.Current.Show("title", "body", 1, DateTime.Now.AddSeconds(5));
        }

        private async Task OnTestePopupPage()
        {
            await NavigationService.NavigateAsync("TestePopupPage");
        }
    }
}

using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCondominioSmart.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IList<int> ListaTeste { get; set; }
        protected LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : 
            base(navigationService, pageDialogService)
        {
            ListaTeste = new ObservableRangeCollection<int>();
            GetLista();
        }

        private void GetLista()
        {
            for (int i = 0; i < 1000; i++)
            {
                ListaTeste.Add(i);
            }
        }

        public DelegateCommand TestePageCommand => new DelegateCommand(async () => await OnTestePage());

        private async Task OnTestePage()
        {
            await NavigationService.NavigateAsync("/TestePage");
        }
    }
}

using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ProjetoCondominioSmart.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        protected LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : 
            base(navigationService, pageDialogService)
        {
        }

        public DelegateCommand TestePageCommand => new DelegateCommand(async () => await OnTestePage());

        private async Task OnTestePage()
        {
            await NavigationService.NavigateAsync("/TestePage");
        }
    }
}

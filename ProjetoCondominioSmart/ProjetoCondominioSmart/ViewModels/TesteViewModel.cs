using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace ProjetoCondominioSmart.ViewModels
{
    public class TesteViewModel : BaseViewModel
    {
        protected TesteViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService, pageDialogService)
        {
        }
        public DelegateCommand TestePopupPageCommand => new DelegateCommand(async () => await OnTestePopupPage());

        private async Task OnTestePopupPage()
        {
            await NavigationService.NavigateAsync("TestePopupPage");
        }
    }
}

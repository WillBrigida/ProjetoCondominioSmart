using Prism.Navigation;
using Prism.Services;

namespace ProjetoCondominioSmart.ViewModels
{
    public class ReclamacaoViewModel : BaseViewModel
    {
        protected ReclamacaoViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : 
            base(navigationService, pageDialogService)
        {
        }
    }
}

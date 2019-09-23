using Prism.Navigation;
using Prism.Services;
using ProjetoCondominioSmart.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjetoCondominioSmart.ViewModels
{
    public class ListaTesteViewModel : BaseViewModel
    {
        public IList<Pessoa> ListaPessoa { get; set; }
        protected ListaTesteViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ListaPessoa = new ObservableCollection<Pessoa>();
            GetListaPessoa();
        }

        private void GetListaPessoa()
        {
            var lista = new List<Pessoa>()
            {
                new Pessoa("Arthur"),
                new Pessoa("Duda"),
                new Pessoa("Luiza"),
                new Pessoa("Flavia"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                 new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"), new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
                new Pessoa("Victória"),
            };

            foreach (var item in lista)
                ListaPessoa.Add(item);
        }
    }
}

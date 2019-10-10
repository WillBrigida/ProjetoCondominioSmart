using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ProjetoCondominioSmart.Models;
using ProjetoCondominioSmart.Services;
using System;

namespace ProjetoCondominioSmart.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region ATRIBUTOS E PROPRIEDADES
        readonly IFacebookService _facebookService;
        readonly IGoogleService _googleService;
        #endregion

        #region CONSTRUTOR
        protected LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IFacebookService facebookService, IGoogleService googleService) :
           base(navigationService, pageDialogService)
        {
            _facebookService = facebookService;
            _googleService = googleService;
        }
        #endregion

        #region COMMANDS
    public DelegateCommand GoogleLoginCommand => new DelegateCommand(OnGoogleLogin);

      

        public DelegateCommand FacebookLoginCommand => new DelegateCommand(OnFacebookLogin);

       
        #endregion

        #region METODOS
        private void OnGoogleLogin()
        {
            _googleService?.Login(OnLoginComplete);
        }
       
        private void OnFacebookLogin()
        {
            _facebookService?.Login(OnLoginComplete);
        }

        private void OnLoginComplete(UsuarioRedeSocial usuario, string exception)
        {
            if (string.IsNullOrEmpty(exception))
            {

                Xamarin.Forms.MessagingCenter.Send(new Users(users.Id, users.Token, users.FirstName,
                                                                      users.LastName, users.Email, users.Picture)
                { Pic = users.Pic }, "login");
            }
            else
            {
                Debug.WriteLine($"====={exception}=====");
                await App.Current.MainPage.DisplayAlert("Error", exception, "OK");
            }
        }

        #endregion
    }
}

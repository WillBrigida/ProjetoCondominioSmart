using ProjetoCondominioSmart.Models;
using System;

namespace ProjetoCondominioSmart.Services
{
    public interface IFacebookService
    {
        void Login(Action<UsuarioRedeSocial, string> onLoginComplete);
        void Logout();
    }
}

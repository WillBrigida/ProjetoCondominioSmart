using ProjetoCondominioSmart.Models;
using System;

namespace ProjetoCondominioSmart.Services
{
    public interface IGoogleService
    {
        void Login(Action<UsuarioRedeSocial, string> OnLoginComplete);
        void Logout();
    }
}

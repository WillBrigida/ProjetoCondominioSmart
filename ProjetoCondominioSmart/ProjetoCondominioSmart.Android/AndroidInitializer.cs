using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using ProjetoCondominioSmart.Droid.Services;
using ProjetoCondominioSmart.Services;

namespace ProjetoCondominioSmart.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
            {
                containerRegistry.Register<IGoogleService, GoogleService>();
                containerRegistry.Register<IFacebookService, FacebookService>();
            }
        }
    }
}
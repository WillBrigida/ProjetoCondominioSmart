using Com.OneSignal;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;

namespace ProjetoCondominioSmart.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
        }
    }
}
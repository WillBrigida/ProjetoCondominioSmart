using Com.OneSignal;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Plugin.Popups;
using ProjetoCondominioSmart.ViewModels;
using ProjetoCondominioSmart.ViewModels.Popup;
using ProjetoCondominioSmart.Views;
using ProjetoCondominioSmart.Views.Popup;
using Xamarin.Forms;

namespace ProjetoCondominioSmart
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : this(initializer, true) { }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver) : base(initializer, setFormsDependencyResolver) { }

        protected override async void OnInitialized()
        {
            await Push.SetEnabledAsync(true);
            InitializeComponent();
           
#if DEBUG
            HotReloader.Current.Run(this);
#endif

            await NavigationService.NavigateAsync("LoginPage");

            AppCenter.Start("fbc76f48-6398-4429-9653-3caa5f6daa44",
                              typeof(Push), typeof(Crashes), typeof(Analytics));

            OneSignal.Current.StartInit("1e582819-6647-4e7a-aa34-c87d221423eb")
                  .EndInit();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<TestePage, TesteViewModel>();
            containerRegistry.RegisterForNavigation<TestePopupPage, TestePopupViewModel>();
        }

        //protected override void OnStart()
        //{
        //    AppCenter.Start("fbc76f48-6398-4429-9653-3caa5f6daa44",
        //                       typeof(Analytics), typeof(Crashes));
        //}
    }
}


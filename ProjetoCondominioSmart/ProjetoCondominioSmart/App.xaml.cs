using Com.OneSignal;
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
      
        public App(IPlatformInitializer initializer): this(initializer, true) { }
      
        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver) : base(initializer, setFormsDependencyResolver) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Run(this);
#endif

            await NavigationService.NavigateAsync("TestePage");

            OneSignal.Current.StartInit("5bd3b9d2-1a0c-417d-89d1-3a3d9fb10cfc")
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
    }
}


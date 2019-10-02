<<<<<<< HEAD
﻿using Microsoft.AppCenter;
=======
﻿using Com.OneSignal;
using Microsoft.AppCenter;
>>>>>>> master
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Plugin.Popups;
using ProjetoCondominioSmart.ViewModels;
using ProjetoCondominioSmart.ViewModels.Popup;
using ProjetoCondominioSmart.Views;
using ProjetoCondominioSmart.Views.Popup;
using System.Collections.Generic;
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
            InitializeComponent();
<<<<<<< HEAD
            //#if DEBUG
            //            HotReloader.Current.Run(this);

            await NavigationService.NavigateAsync("LoginPage");

            AppCenter.Start("android=c2f894c9-c22c-4e95-965e-8365c6a82c65;",
                  typeof(Analytics), typeof(Crashes));
=======
#if DEBUG
            HotReloader.Current.Run(this);
#endif

            await NavigationService.NavigateAsync("TestePage");

            OneSignal.Current.StartInit("5bd3b9d2-1a0c-417d-89d1-3a3d9fb10cfc")
                 .EndInit();

            AppCenter.Start("android=d1466097-4979-46a5-aba1-9ee42a8ccb6b;",
                  typeof(Analytics), typeof(Crashes));


>>>>>>> master
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


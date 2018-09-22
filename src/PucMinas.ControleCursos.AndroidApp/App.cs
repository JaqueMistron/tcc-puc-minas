using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using PucMinas.ControleCursos.AndroidApp.ViewModel;

namespace PucMinas.ControleCursos.AndroidApp
{
    public static class App
    {
        private static ViewModelLocator locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    DispatcherHelper.Initialize();

                    var nav = new NavigationService();

                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    nav.Configure(
                      ViewModelLocator.InicioPageKey,
                      typeof(InicioActivity));

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}
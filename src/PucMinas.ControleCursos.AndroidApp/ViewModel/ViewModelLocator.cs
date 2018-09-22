using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace PucMinas.ControleCursos.AndroidApp.ViewModel
{
    public class ViewModelLocator
    {
        /// <summary>
        /// The key used by the NavigationService to go to the second page.
        /// </summary>
        public const string InicioPageKey = "InicioPage";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<AutenticarViewModel>();
        }

        public AutenticarViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AutenticarViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
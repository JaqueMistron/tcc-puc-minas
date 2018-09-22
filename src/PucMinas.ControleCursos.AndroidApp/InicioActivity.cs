using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;

namespace PucMinas.ControleCursos.AndroidApp
{
    [Activity(Label = "Início")]
    public class InicioActivity : ActivityBase
    {
        private Button voltarButton;
        public Button VoltarButton
        {
            get
            {
                return voltarButton
                    ?? (voltarButton = FindViewById<Button>(Resource.Id.btnSair));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.InicioView);

            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            VoltarButton.Click += (s, e) => nav.GoBack();
        }
    }
}
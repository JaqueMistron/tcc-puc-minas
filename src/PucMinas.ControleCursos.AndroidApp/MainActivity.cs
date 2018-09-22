using Android.App;
using Android.Widget;
using Android.OS;
using PucMinas.ControleCursos.AndroidApp.ViewModel;
using PucMinas.ControleCursos.AndroidApp;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;

namespace PucMinas.ControleCursos.Application
{
    [Activity(Label = "Controle de Cursos", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ActivityBase
    {
        private readonly List<Binding> bindings = new List<Binding>();

        private AutenticarViewModel Vm
        {
            get
            {
                return App.Locator.Main;
            }
        }

        private TextView txtTituloPagina;
        public TextView TituloPaginaText
        {
            get
            {
                return txtTituloPagina
                    ?? (txtTituloPagina = FindViewById<TextView>(Resource.Id.txtTituloPagina));
            }
        }

        private TextView txtNomeUsuario;
        public TextView NomeUsuarioText
        {
            get
            {
                return txtNomeUsuario
                    ?? (txtNomeUsuario = FindViewById<TextView>(Resource.Id.nomeUsuario));
            }
        }

        private TextView txtSenha;
        public TextView SenhaText
        {
            get
            {
                return txtSenha
                    ?? (txtSenha = FindViewById<TextView>(Resource.Id.senha));
            }
        }

        private TextView txtErroAutenticacao;
        public TextView ErroAutenticacaoText
        {
            get
            {
                return txtErroAutenticacao
                    ?? (txtErroAutenticacao = FindViewById<TextView>(Resource.Id.txtErroAutenticacao));
            }
        }

        private Button btnEntrar;
        public Button EntrarButton
        {
            get
            {
                return btnEntrar
                    ?? (btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AutenticarView);

            bindings.Add(
                this.SetBinding(
                    () => Vm.TituloPagina,
                    () => TituloPaginaText.Text, BindingMode.TwoWay));
            bindings.Add(
                this.SetBinding(
                    () => Vm.ResultadoAutenticacao,
                    () => ErroAutenticacaoText.Text, BindingMode.TwoWay));
            bindings.Add(
                this.SetBinding(
                    () => Vm.Usuario,
                    () => NomeUsuarioText.Text, BindingMode.TwoWay));
            bindings.Add(
                this.SetBinding(
                    () => Vm.Senha,
                    () => SenhaText.Text, BindingMode.TwoWay));

            EntrarButton.SetCommand(
                "Click",
                Vm.EntrarCommand);
        }
    }
}


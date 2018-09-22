using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PucMinas.ControleCursos.AndroidApp.Model;
using PucMinas.ControleCursos.AndroidApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PucMinas.ControleCursos.AndroidApp.ViewModel
{
    public class AutenticarViewModel : ViewModelBase
    {
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                RaisePropertyChanged(propertyName: nameof(Usuario));
            }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; RaisePropertyChanged(propertyName: nameof(Senha)); }
        }

        private string _resultadoAutenticacao;
        public string ResultadoAutenticacao
        {
            get { return _resultadoAutenticacao; }
            set { _resultadoAutenticacao = value; RaisePropertyChanged(propertyName: nameof(ResultadoAutenticacao)); }
        }

        private ObservableCollection<Aluno> _listaAlunos;
        public ObservableCollection<Aluno> ListaAlunos
        {
            get { return _listaAlunos; }
            set { _listaAlunos = value; RaisePropertyChanged(() => ListaAlunos); }
        }

        private string tituloPagina;

        private RelayCommand entrarCommand;

        private readonly INavigationService navigationService;

        public string TituloPagina
        {
            get
            {
                return tituloPagina;
            }
            set
            {
                Set(ref tituloPagina, value);
            }
        }

        private static AlunoService alunoService;

        public RelayCommand EntrarCommand
        {
            get
            {
                return entrarCommand
                ?? (entrarCommand = new RelayCommand(() => Autenticar()));
            }
        }

        private async void Autenticar()
        {
            if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Senha))
            {
                var retorno = await alunoService.AutenticarAsync(new Aluno() { Email = Usuario, Senha = Senha });
                ResultadoAutenticacao = retorno;

                if (string.IsNullOrEmpty(retorno))
                {
                    LimparCampos();
                    navigationService.NavigateTo(ViewModelLocator.InicioPageKey);
                }
            }
            else
            {
                LimparCampos();
                ResultadoAutenticacao = "Para entrar, informe seu usuário e senha";
            }
        }

        public AutenticarViewModel(INavigationService navigationService)
        {
            alunoService = new AlunoService();
            this.navigationService = navigationService;

            TituloPagina = "Controle de Cursos";
        }

        private void LimparCampos()
        {
            Usuario = string.Empty;
            Senha = string.Empty;
            ResultadoAutenticacao = string.Empty;
        }
    }
}

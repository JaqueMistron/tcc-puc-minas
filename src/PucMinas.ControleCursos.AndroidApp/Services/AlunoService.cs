using Newtonsoft.Json;
using PucMinas.ControleCursos.AndroidApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PucMinas.ControleCursos.AndroidApp.Services
{
    public class AlunoService
    {
        public async Task<string> AutenticarAsync(Aluno aluno)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                string paramEmail = !string.IsNullOrEmpty(aluno.Email) ? aluno.Email : "vazio";
                string paramSenha = !string.IsNullOrEmpty(aluno.Senha) ? aluno.Senha : "vazio";

                string url = "http://pucminascontrolecursoswebapi.azurewebsites.net/api/v1/aluno/realizarAutenticacao/{0}/{1}";
                var uri = new Uri(string.Format(url, paramEmail, paramSenha));
                var response = await httpClient.GetStringAsync(uri);
                var alunos = JsonConvert.DeserializeObject<List<Aluno>>(response);

                if (alunos != null && alunos.Count > 0)
                    return string.Empty;

                return "Usuário e/ou senha não encontrados";
            }
            catch (HttpRequestException ex)
            {
                return "Erro ao autenticar: " + ex.Message;
            }
        }

        public async Task<List<Aluno>> ListarTodosAsync()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                string url = "http://pucminascontrolecursoswebapi.azurewebsites.net/api/v1/aluno/listarTodos";
                var uri = new Uri(url);
                var response = await httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Aluno>>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

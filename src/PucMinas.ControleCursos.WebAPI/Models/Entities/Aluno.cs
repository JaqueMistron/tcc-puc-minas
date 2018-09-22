using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PucMinas.ControleCursos.WebAPI.Models.Entities
{
    public class Aluno
    {
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

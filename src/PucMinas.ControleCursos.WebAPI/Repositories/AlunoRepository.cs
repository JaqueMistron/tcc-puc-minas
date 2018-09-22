using PucMinas.ControleCursos.WebAPI.Models.Entities;
using PucMinas.ControleCursos.WebAPI.Models.Interfaces;
using PucMinas.ControleCursos.WebAPI.Repositories.Context;

namespace PucMinas.ControleCursos.WebAPI.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>, IAluno
    {
        public AlunoRepository(SqliteContext context) : base(context)
        {
        }
    }
}

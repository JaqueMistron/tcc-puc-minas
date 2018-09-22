using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PucMinas.ControleCursos.WebAPI.Models.Entities;
using PucMinas.ControleCursos.WebAPI.Models.Interfaces;
using PucMinas.ControleCursos.WebAPI.Services.Interfaces;

namespace PucMinas.ControleCursos.WebAPI.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAluno _alunoRepository;

        public AlunoService(IAluno alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool Any(Expression<Func<Aluno, bool>> predicate)
        {
            return _alunoRepository.Any(predicate);
        }

        public void Delete(long cpf)
        {
            _alunoRepository.Delete(cpf);
        }

        public IEnumerable<Aluno> Find(Expression<Func<Aluno, bool>> predicate)
        {
            return _alunoRepository.Find(predicate);
        }

        public IEnumerable<Aluno> FindAll()
        {
            return _alunoRepository.FindAll();
        }

        public Aluno FindById(long cpf)
        {
            return _alunoRepository.FindById(cpf);
        }

        public void Insert(Aluno entity)
        {
            _alunoRepository.Insert(entity);
        }

        public void Update(Aluno entity)
        {
            _alunoRepository.Update(entity);
        }
    }
}

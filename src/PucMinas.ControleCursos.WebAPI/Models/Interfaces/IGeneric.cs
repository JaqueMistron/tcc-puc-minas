using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PucMinas.ControleCursos.WebAPI.Models.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(long cpf);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T FindById(long Cpf);
        IEnumerable<T> FindAll();
        bool Any(Expression<Func<T, bool>> predicate);
    }
}

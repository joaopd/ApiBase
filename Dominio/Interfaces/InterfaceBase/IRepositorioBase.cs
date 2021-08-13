using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> Create(T objeto);
        Task<T> Delete(T objeto);
        Task<T> Update(T objeto);
        Task<T> GetById(Guid Id);
        Task<List<T>> GetList(Expression<Func<T, bool>> expression = null,
                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}

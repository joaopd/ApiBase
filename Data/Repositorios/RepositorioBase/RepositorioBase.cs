using Api.Data.Context;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntidadeBase
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _dataSet;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<T> Create(T objeto)
        {
            try
            {
                _dataSet.Add(objeto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objeto;
        }

        public async Task<T> Delete(T objeto)
        {
            try
            {
                _dataSet.Remove(objeto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objeto;
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _dataSet.FindAsync(Id);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> qry = _dataSet.AsNoTracking();

            if (expression != null)
            {
                qry = qry.Where(expression);
            }
            if (include != null)
            {
                qry = include(qry);
            }

            return await qry.ToListAsync();
        }

        public async Task<T> Update(T objeto)
        {
            try
            {
                T result = await _dataSet.FindAsync(objeto.Id);
                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(objeto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objeto;
        }
    }
}

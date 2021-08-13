using Api.Data.Context;
using Data.Repositorios;
using Dominio.Interfaces;
using Dominio.UoW;

namespace Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepositorioUsuario _repositorioUsuario;

        public IRepositorioUsuario RepositorioUsuario
        {
            get
            {
                if (_repositorioUsuario == null) { _repositorioUsuario = new RepositorioUsuario(_context); }
                return _repositorioUsuario;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

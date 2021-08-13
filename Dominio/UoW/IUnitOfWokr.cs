using Dominio.Interfaces;

namespace Dominio.UoW
{
    public interface IUnitOfWork
    {
        void Commit();

        public IRepositorioUsuario RepositorioUsuario { get; }
    }
}

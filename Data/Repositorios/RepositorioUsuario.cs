using Api.Data.Context;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Data.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext context) : base(context)
        {
        }
    }
}

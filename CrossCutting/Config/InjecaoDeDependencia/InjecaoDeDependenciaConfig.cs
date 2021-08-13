using Data.Repositorios;
using Data.UoW;
using Dominio.Interfaces;
using Dominio.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Config.InjecaoDeDependencia
{
    public static class InjecaoDeDependenciaConfig
    {
        public static void ConfiguracaoInjecaoDeDependencia(IServiceCollection service)
        {
            ConfiguracaoRepositorioBase(service);
            ConfiguracaoRepositorioUsuario(service);
            ConfiguracaoRepositorioUnitOfWork(service);

        }

        public static void ConfiguracaoRepositorioBase(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
        }
        public static void ConfiguracaoRepositorioUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfiguracaoRepositorioUsuario(IServiceCollection services)
        {
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
        }
    }
}

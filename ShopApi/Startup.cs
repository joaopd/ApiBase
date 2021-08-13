using CrossCutting.Config.Data;
using CrossCutting.Config.InjecaoDeDependencia;
using CrossCutting.Config.Swagger;
using CrossCutting.Config.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAutoMapper(typeof(Startup));

            InjecaoDeDependenciaConfig.ConfiguracaoInjecaoDeDependencia(services);

            DataConfig.DataConfigure(services, Configuration);

            SwaggerConfig.SwaggerConfigureService(services);

            AuthConfig.ConfiguracaoAuth(services);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SwaggerConfig.SwagerConfigure(app, env);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TechChallenge_1.Base.Configuracoes;
using TechChallenge_1.Domain.Repositorio;
using TechChallenge_1.Infra.Data.Contexts;
using TechChallenge_1.Infra.Data.Feature;

namespace TechChallenge_1.Infra.Data
{
    public static class Inicializacao
    {
        public static void AdicionarDependenciasRepositorio(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            services.AddScoped((Func<IServiceProvider, ContatoDbContext>)((ctx) =>
            {
                var options = new DbContextOptionsBuilder<ContatoDbContext>()
                                 .UseSqlServer(appSettings.ConnectionString,
                                  opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)).Options;

                return new Contexts.ContatoDbContext(options);
            }));

            services.AddTransient<IRepositorioContato, ContatoRepository>();
        }
    }
}
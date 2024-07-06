using Microsoft.Extensions.DependencyInjection;

using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.PersistirDados;
using TechChallenge_1.Domain.Features.RemoverContato.Modulos.Execucao;
using TechChallenge_1.Domain.Features.RemoverContato.Modulos.PersistirDados;

namespace TechChallenge_1.Domain
{
    public static class Inicializacao
    {
        public static IServiceCollection InicializarDomain(this IServiceCollection services)
        {
            AdicionarDependenciasContatos(services);

            return services;
        }

        private static void AdicionarDependenciasContatos(IServiceCollection services)
        {
            services.AddTransient<IPersistirDadosRemoverContato, PersistirDadosRemoverContatoImpl>();
            services.AddTransient<IExecucaoRemoverContato, ExecucaoRemoverContatoImpl>();
            services.AddTransient<IPersistirDadosAdicionarContato, PersistirDadosAdicionarContatoImpl>();
            services.AddTransient<IExecucaoAdicionarContato, ExecucaoAdicionarContatoImpl>();

        }
    }
}

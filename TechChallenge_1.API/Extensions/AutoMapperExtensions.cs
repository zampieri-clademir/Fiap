using AutoMapper;

using System.Diagnostics.CodeAnalysis;

using TechChallenge_1.API.Features.Contato;
using TechChallenge_1.Application;
using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Application.Features.Contato.RemoverContato;

namespace TechChallenge_1.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            try
            {
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(AdicionarContatoApplicationMapper).Assembly);
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(RemoverContatoApplicationMapper).Assembly);
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(ContatoControllerMapper).Assembly);
            }
            catch (Exception)
            {
            }
        }
    }
}

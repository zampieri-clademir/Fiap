using TechChallenge_1.Domain.Features.AdicionarContato.Contexto;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Modulos.PersistirDados
{
    public interface IPersistirDadosAdicionarContato
    {
        Guid Processar(ContextoAdicionarContato contexto);
    }
}
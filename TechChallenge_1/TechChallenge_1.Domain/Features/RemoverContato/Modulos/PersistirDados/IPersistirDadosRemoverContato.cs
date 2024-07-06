using TechChallenge_1.Domain.Features.RemoverContato.Contexto;

namespace TechChallenge_1.Domain.Features.RemoverContato.Modulos.PersistirDados
{
    public interface IPersistirDadosRemoverContato
    {
        bool Processar(ContextoRemoverContato contexto);
    }
}
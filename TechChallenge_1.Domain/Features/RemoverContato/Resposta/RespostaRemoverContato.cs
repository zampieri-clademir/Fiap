using TechChallenge_1.Domain.Features.RemoverContato.Contexto;

namespace TechChallenge_1.Domain.Features.RemoverContato.Resposta
{
    public class RespostaRemoverContato
    {
        public bool Successo { get; set; }

        public ContextoRemoverContato Contexto { get; set; }
    }
}
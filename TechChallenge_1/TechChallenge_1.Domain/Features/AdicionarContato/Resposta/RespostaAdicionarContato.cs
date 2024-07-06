using TechChallenge_1.Domain.Features.AdicionarContato.Contexto;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Resposta
{
    public class RespostaAdicionarContato
    {
        public Guid IdContato { get; set; }

        public ContextoAdicionarContato Contexto { get; set; }
    }
}
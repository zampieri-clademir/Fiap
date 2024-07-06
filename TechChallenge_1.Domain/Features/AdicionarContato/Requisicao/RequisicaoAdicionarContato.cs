using TechChallenge_1.Domain.Entidades.Contato;

namespace TechChallenge_1.Domain.Features.AdicionarContato.Requisicao
{
    public class RequisicaoAdicionarContato
    {
        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public short Ddd { get; set; }
    }
}

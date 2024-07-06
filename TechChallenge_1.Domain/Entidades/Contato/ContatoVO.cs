using System.Diagnostics.CodeAnalysis;

namespace TechChallenge_1.Domain.Entidades.Contato
{
    [ExcludeFromCodeCoverage]
    public class ContatosVO
    {
        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public short Ddd { get; set; }
    }
}

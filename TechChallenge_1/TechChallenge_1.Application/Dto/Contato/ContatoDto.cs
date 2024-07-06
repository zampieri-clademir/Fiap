using System.Diagnostics.CodeAnalysis;

namespace TechChallenge_1.Application.Dto.Contato
{
    [ExcludeFromCodeCoverage]
    public class ContatoDto
    {
        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public short Ddd { get; set; }
    }
}

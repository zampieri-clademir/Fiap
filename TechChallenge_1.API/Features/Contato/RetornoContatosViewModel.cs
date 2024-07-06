using System.Diagnostics.CodeAnalysis;

using TechChallenge_1.Application.Dto.Contato;

namespace TechChallenge_1.API.Features.Contato
{
    [ExcludeFromCodeCoverage]
    public class RetornoContatosViewModel
    {
        public List<ContatoDto> ListaContatos { get; set; }
    }
}


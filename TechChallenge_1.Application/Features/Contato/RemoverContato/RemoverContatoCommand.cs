using MediatR;

using System.ComponentModel.DataAnnotations;

using TechChallenge_1.API.Base;

namespace TechChallenge_1.Application.Features.Contato.RemoverContato
{
    public class RemoverContatoCommand : IRequest<bool>
    {

        [Required(ErrorMessage = "O Guid � obrigat�rio.")]
        [ValidGuid(ErrorMessage = "O Guid fornecido n�o � v�lido.")]
        public string IdContato { get; set; }
    }
}

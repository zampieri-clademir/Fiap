using MediatR;

using System.ComponentModel.DataAnnotations;

using TechChallenge_1.API.Base;

namespace TechChallenge_1.Application.Features.Contato.RemoverContato
{
    public class RemoverContatoCommand : IRequest<bool>
    {

        [Required(ErrorMessage = "O Guid é obrigatório.")]
        [ValidGuid(ErrorMessage = "O Guid fornecido não é válido.")]
        public string IdContato { get; set; }
    }
}

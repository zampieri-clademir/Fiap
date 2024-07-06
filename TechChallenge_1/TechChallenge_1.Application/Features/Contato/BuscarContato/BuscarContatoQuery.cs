using FluentValidation;

using MediatR;

using System.ComponentModel.DataAnnotations;

using TechChallenge_1.Domain.Entidades.Contato;

namespace NDD.Portal.NFe.Application.Features.Emissao.Queries.BuscarDocumento
{
    public class BuscarContatoQuery : IRequest<List<ContatosVO>>
    {
        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [Range(11, 99, ErrorMessage = "O DDD deve estar entre 11 e 99.")]
        public virtual short Ddd { get; set; }
    }

    public class ConsultarContatoQueryValidator : AbstractValidator<BuscarContatoQuery>
    {
        public ConsultarContatoQueryValidator()
        {
            RuleFor(d => d.Ddd).NotNull().NotEmpty();
        }
    }
}
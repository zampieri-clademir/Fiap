using MediatR;

using System.ComponentModel.DataAnnotations;

namespace TechChallenge_1.Application.Features.Contato.AdicionarContato
{
    public class AdicionarContatoCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone deve ser válido.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [Range(11, 99, ErrorMessage = "O DDD deve estar entre 11 e 99.")]
        public short Ddd { get; set; }
    }
}

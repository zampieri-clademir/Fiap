using MediatR;

using System.ComponentModel.DataAnnotations;

namespace TechChallenge_1.Application.Features.Contato.AdicionarContato
{
    public class AdicionarContatoCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no m�ximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "O email deve ser v�lido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no m�ximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio.")]
        [Phone(ErrorMessage = "O telefone deve ser v�lido.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no m�ximo 15 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O DDD � obrigat�rio.")]
        [Range(11, 99, ErrorMessage = "O DDD deve estar entre 11 e 99.")]
        public short Ddd { get; set; }
    }
}

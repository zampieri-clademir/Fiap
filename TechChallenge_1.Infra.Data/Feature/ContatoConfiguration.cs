using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TechChallenge_1.Base.Constantes;
using TechChallenge_1.Domain.Entidades.Contato;

namespace TechChallenge_1.Infra.Data.Feature
{
    public class ContatoConfiguration : IEntityTypeConfiguration<ContatosVO>
    {
        public void Configure(EntityTypeBuilder<ContatosVO> builder)
        {
            builder.ToTable("Contatos", Constantes.NomeSchema);

            builder.HasKey(c => c.ContatoId);

            builder.Property(c => c.ContatoId).IsRequired();
            builder.Property(c => c.Nome);
            builder.Property(c => c.Email);
            builder.Property(c => c.Telefone);
            builder.Property(c => c.Ddd);
        }
    }
}
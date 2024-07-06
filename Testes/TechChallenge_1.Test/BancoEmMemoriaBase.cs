
using Microsoft.EntityFrameworkCore;
using TechChallenge_1.Infra.Data.Contexts;

using System.Diagnostics.CodeAnalysis;
using TechChallenge_1.Domain.Entidades.Contato;

namespace TechChallenge_1.Test
{
    [ExcludeFromCodeCoverage]
    public abstract class BancoEmMemoriaBase
    {
        protected ContatoDbContext ContatoContext { get; private set; }

        protected BancoEmMemoriaBase()
        {
            Init();
        }

        private void Init()
        {
            var optionsCore = new DbContextOptionsBuilder<ContatoDbContext>()
                .UseInMemoryDatabase("ContatoDbContext")
                .Options;

            ContatoContext = new ContatoDbContext(optionsCore);

            Populate();

            ContatoContext.SaveChanges();
        }

        private void Populate()
        {
            PopulateApplicationUserData();
        }

        private void PopulateApplicationUserData()
        {
            ContatoContext.Set<ContatosVO>().Add(new ContatosVO() { ContatoId = Guid.NewGuid(), Nome = "Clademir Zampieri", Email="mr.zampieri@live.com", Telefone = "49999041779", Ddd = 11});
        }
    }
}

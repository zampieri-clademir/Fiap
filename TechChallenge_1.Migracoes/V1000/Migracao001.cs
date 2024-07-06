using FluentMigrator;

using TechChallenge_1.Base.Constantes;

namespace TechChallenge_1.Migracoes.V1000
{
    [Migration(2024050000001, TransactionBehavior.Default)]
    public class Migracao2024050000001 : Migration
    {
        public Migracao2024050000001()
        {
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            AdicionarTabelaContatos();
        }

        private void AdicionarTabelaContatos()
        {
            if (!Schema.Schema(Constantes.NomeSchema).Table("Contatos").Exists())
            {
                string script = $@"CREATE TABLE [{Constantes.NomeSchema}].[Contatos](
								[ContatoId] [uniqueidentifier] DEFAULT NEWID() NOT NULL,
								[Nome] [varchar](300) NOT NULL,
								[Email] [varchar](300) NULL,
								[Telefone] [varchar](50) NULL,								
								[Ddd] [smallint] NOT NULL,
							    CONSTRAINT [PK_NFeRecepcaoEventosTerceiros_DataEmissao_Id] PRIMARY KEY CLUSTERED
						        (
							        [ContatoId] ASC
						        ))";

                Execute.Sql(script);
            }
        }
    }
}

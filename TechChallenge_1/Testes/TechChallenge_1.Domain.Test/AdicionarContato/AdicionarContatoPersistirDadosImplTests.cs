using Moq;

using NUnit.Framework;

using TechChallenge_1.Application.Features.Contato.AdicionarContato;
using TechChallenge_1.Domain.Entidades.Contato;
using TechChallenge_1.Domain.Features.AdicionarContato.Contexto;
using TechChallenge_1.Domain.Features.AdicionarContato.Modulos.PersistirDados;
using TechChallenge_1.Domain.Features.AdicionarContato.Requisicao;
using TechChallenge_1.Domain.Repositorio;

namespace TechChallenge_1.Domain.Test.AdicionarContato
{
    [TestFixture]
    public class AdicionarContatoPersistirDadosImplTests
    {
        private Mock<IRepositorioContato> _repositorioMock;
        private PersistirDadosAdicionarContatoImpl _persistirDados;

        [SetUp]
        public void SetUp()
        {
            _repositorioMock = new Mock<IRepositorioContato>();
            _persistirDados = new PersistirDadosAdicionarContatoImpl(_repositorioMock.Object);
        }

        [Test]
        public void Processar_ValidContext_ReturnsGuid()
        {
            // Arrange
            var contexto = new ContextoAdicionarContato
            {
                Requisicao = new RequisicaoAdicionarContato
                {
                    Nome = "Teste Nome",
                    Email = "teste@exemplo.com",
                    Telefone = "123456789",
                    Ddd = 11
                }
            };

            var expectedGuid = Guid.NewGuid();
            _repositorioMock.Setup(r => r.SalvarContatoAsync(It.IsAny<ContatosVO>())).ReturnsAsync(expectedGuid);

            // Act
            var result = _persistirDados.Processar(contexto);

            // Assert
            Assert.AreEqual(expectedGuid, result);
        }
    }
}

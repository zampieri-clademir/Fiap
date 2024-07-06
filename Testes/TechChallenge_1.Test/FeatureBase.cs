using NUnit.Framework;

using System.Diagnostics.CodeAnalysis;

namespace TechChallenge_1.Test
{
    [ExcludeFromCodeCoverage]
    public abstract class FeatureBase : BancoEmMemoriaBase
    {
        public void Executar()
        {
            bool emExecucao = true;

            Inicializar();

            DadoDeterminadaSituacao();

            try
            {
                QuandoExecutado();
                emExecucao = false;

                EntaoVerificar();
            }
            catch (Exception e) when (!(e is AssertionException))
            {
                if (emExecucao)
                    EntaoVerificar(e);
                else
                    throw;
            }
            finally
            {
                Finalizar();
            }
        }

        protected abstract void Inicializar();

        protected abstract void DadoDeterminadaSituacao();

        protected abstract void QuandoExecutado();

        protected abstract void EntaoVerificar(Exception exception = null);

        protected virtual void Finalizar()
        {
            ContatoContext.Database.EnsureDeleted();

            ContatoContext.Dispose();
        }
    }
}

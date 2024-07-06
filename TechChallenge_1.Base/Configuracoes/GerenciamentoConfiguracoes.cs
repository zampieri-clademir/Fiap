namespace TechChallenge_1.Base.Configuracoes
{
    public class GerenciamentoConfiguracoes
    {
        public AppSettings? AppSettings { get; set; }

        public AuthSettings? AuthSettings { get; set; }

        public string? CaminhoArquivoLog { get; set; }

        public string? CaminhoMiddlewareXml { get; set; }
    }
}

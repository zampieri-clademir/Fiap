namespace TechChallenge_1.Base.Configuracoes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SwaggerIgnoreAttribute : Attribute
    { }
}

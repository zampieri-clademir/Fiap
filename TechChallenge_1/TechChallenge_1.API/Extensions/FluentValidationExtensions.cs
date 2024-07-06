using FluentValidation;

using SimpleInjector;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TechChallenge_1.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class FluentValidationExtensions
    {
        public static void AddValidators(this IServiceCollection services, Container container)
        {
            container.Collection.Register(typeof(IValidator<>), typeof(Application.AppModule).GetTypeInfo().Assembly);
        }
    }
}

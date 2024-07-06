using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;

using System.Diagnostics.CodeAnalysis;

namespace TechChallenge_1.API.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                               where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            return await next();
        }
    }
}

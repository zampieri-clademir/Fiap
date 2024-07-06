
using System.Collections.Generic;
using System.Linq;

namespace TechChallenge_1.API.Exceptions
{
    public class ValidationFailureMapper
    {
        public IEnumerable<ValidationFailure> Map(IEnumerable<FluentValidation.Results.ValidationFailure> falhas)
        {
            return falhas.Select(x => new ValidationFailure { Correcao = x.ErrorCode, MensagemDeErro = x.ErrorMessage, Campo = x.PropertyName });
        }
    }
}

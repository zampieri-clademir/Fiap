using AutoMapper;

using TechChallenge_1.Application.Dto.Contato;

namespace TechChallenge_1.API.Features.Contato
{
    public class ContatoControllerMapper : Profile
    {
        public ContatoControllerMapper()
        {
            CreateMap<ContatoDto, RetornoContatosViewModel>();
        }
    }
}


using AutoMapper;
using Conta.Application.DTOs;
using Conta.Domain.Entities;

namespace Conta.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Transacao, ExtratoDto>()
            .ForMember(dest => dest.DataTransacao, opt => opt.MapFrom(src => src.DataTransacao.ToString("dd/MM")))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
            .ForMember(dest => dest.TipoTransacao, opt => opt.MapFrom(src => src.TipoTransacao))
            .ReverseMap();

        CreateMap<Transacao, TransacaoDto>().ReverseMap();       
    }
}
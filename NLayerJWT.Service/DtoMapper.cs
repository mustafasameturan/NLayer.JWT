using AutoMapper;
using NLayerJWT.Core.DTOs;
using NLayerJWT.Core.Models;

namespace NLayerJWT.Service;

public class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<UserAppDto, UserApp>().ReverseMap();
    }
}
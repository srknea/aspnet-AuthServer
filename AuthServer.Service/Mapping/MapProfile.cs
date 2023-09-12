using AuthServer.Core.DTOs;
using AuthServer.Core.Model;
using AutoMapper;

namespace AuthServer.Service.Mapping
{
    // Sadece AuthServer.Service katmanında kullanılacak
    internal class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}

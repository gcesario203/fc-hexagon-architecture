using Adapters.Product.Models;
using Application.Product.Entity;
using AutoMapper;

namespace Adapters.Shared.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductEntityFrameworkModel>().ReverseMap();   
        }
    }
}
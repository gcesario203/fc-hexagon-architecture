using Adapters.Product.Models;
using AutoMapper;

namespace Adapters.Shared.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Application.Product.Entity.ProductEntity, ProductEntityFrameworkModel>().ReverseMap();   
        }
    }
}
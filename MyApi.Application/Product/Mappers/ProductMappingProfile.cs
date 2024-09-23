using AutoMapper;
using MyApi.Application.Product.Responses;


namespace MyApi.Application.Product.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductResponse>().ReverseMap();
        }
    }
}

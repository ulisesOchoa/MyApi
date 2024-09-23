using MediatR;
using MyApi.Application.Product.Mappers;
using MyApi.Application.Product.Queries;
using MyApi.Application.Product.Responses;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Product.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productoList = await _repository.GetAllAsync();
            if (productoList == null || !productoList.Any())
                return Enumerable.Empty<ProductResponse>();

            return ProductMapper.Mapper.Map<IEnumerable<ProductResponse>>(productoList);
        }
    }
}

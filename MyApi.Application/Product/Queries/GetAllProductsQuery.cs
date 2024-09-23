using MediatR;
using MyApi.Application.Product.Responses;

namespace MyApi.Application.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
    }
}

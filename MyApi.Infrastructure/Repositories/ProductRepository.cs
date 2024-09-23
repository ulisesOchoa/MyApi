using MyApi.Domain.Entities;
using MyApi.Domain.Repositories;
using MyApi.Infrastructure.Repositories.Base;

namespace MyApi.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }
    }
}

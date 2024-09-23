using MyApi.Domain.Entities;
using MyApi.Domain.Interfaces;

namespace MyApi.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}

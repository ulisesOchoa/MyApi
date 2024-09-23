using MediatR;
using MyApi.Application.Responses;

namespace MyApi.Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>> { }
}

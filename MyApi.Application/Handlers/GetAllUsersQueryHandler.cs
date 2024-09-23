using MediatR;
using MyApi.Application.Mappers;
using MyApi.Application.Queries;
using MyApi.Application.Responses;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Handlers
{
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var userList = await _repository.GetAllAsync();
            return UserMapper.Mapper.Map<IEnumerable<UserResponse>>(userList);
        }
    }
}

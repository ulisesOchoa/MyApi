using MediatR;
using MyApi.Application.Mappers;
using MyApi.Application.Queries;
using MyApi.Application.Responses;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Handlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.Email);

            return UserMapper.Mapper.Map<UserResponse>(user);
        }
    }
}

using MediatR;
using MyApi.Application.Commands;
using MyApi.Application.Mappers;
using MyApi.Application.Responses;
using MyApi.Domain.Entities;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<User>(request);
            if (userEntity == null)
                throw new ArgumentNullException(nameof(userEntity));

            var newUser = await _repository.AddAsync(userEntity);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);

            return userResponse;
        }
    }
}

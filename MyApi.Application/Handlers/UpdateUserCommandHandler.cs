using MediatR;
using MyApi.Application.Dto;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Handlers
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandWithId, Unit>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommandWithId request, CancellationToken cancellationToken)
        {
            var existingUser = await _repository.GetByIdAsync(request.Id);
            if (existingUser == null)
                throw new ApplicationException($"User with ID {request.Id} not found.");

            existingUser.Name = request.Command.Name ?? existingUser.Name;
            existingUser.LastName = request.Command.LastName ?? existingUser.LastName;
            existingUser.Email = request.Command.Email ?? existingUser.Email;
            existingUser.PhoneNumber = request.Command.PhoneNumber ?? existingUser.PhoneNumber;

            await _repository.UpdateAsync(existingUser);

            return Unit.Value;
        }
    }
}

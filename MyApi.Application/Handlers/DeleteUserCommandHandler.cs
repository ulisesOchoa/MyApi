using MediatR;
using MyApi.Application.Commands;
using MyApi.Domain.Repositories;

namespace MyApi.Application.Handlers
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _repository.GetByIdAsync(request.Id);
            if (existingUser == null)
                throw new ApplicationException($"User with ID {request.Id} not found.");

            await _repository.DeleteAsync(existingUser);

            return Unit.Value;
        }
    }
}

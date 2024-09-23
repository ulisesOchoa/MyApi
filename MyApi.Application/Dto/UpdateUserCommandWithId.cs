using MediatR;
using MyApi.Application.Commands;

namespace MyApi.Application.Dto
{
    public class UpdateUserCommandWithId : IRequest<Unit>
    {
        public int Id { get; }
        public UpdateUserCommand Command { get; }

        public UpdateUserCommandWithId(int id, UpdateUserCommand command)
        {
            Id = id;
            Command = command;
        }
    }
}

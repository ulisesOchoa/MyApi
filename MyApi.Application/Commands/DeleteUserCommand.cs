using MediatR;

namespace MyApi.Application.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}

using MediatR;

namespace MyApi.Application.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

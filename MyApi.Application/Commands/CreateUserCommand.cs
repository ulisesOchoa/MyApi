using MediatR;
using MyApi.Application.Responses;

namespace MyApi.Application.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

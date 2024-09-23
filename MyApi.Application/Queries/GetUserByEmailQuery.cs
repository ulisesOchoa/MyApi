using MediatR;
using MyApi.Application.Responses;

namespace MyApi.Application.Queries
{
    public class GetUserByEmailQuery : IRequest<UserResponse>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email.ToLower();
        }
    }
}

using MyApi.Domain.Entities.Base;

namespace MyApi.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}

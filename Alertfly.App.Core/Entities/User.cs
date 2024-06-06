
namespace Alertfly.App.Core.Entities
{
    public class User : IEntityBase
    {
        public User(string name, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<UserFlight>? UserFlights { get; private set; }   

    }
}

using Domain.Base;

namespace Domain.Personal
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

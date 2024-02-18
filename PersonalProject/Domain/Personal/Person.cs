using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Personal
{
    [Index(nameof(Email), IsUnique = true)]
    public class Person : BaseEntity
    {
        public Person()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

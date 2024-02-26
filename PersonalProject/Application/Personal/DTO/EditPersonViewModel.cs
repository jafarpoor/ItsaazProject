using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Personal.DTO
{
    public class EditPersonViewModel
    {
        //public EditPersonViewModel()
        //{
        //    Firstname = string.Empty;
        //    Lastname = string.Empty;
        //    PhoneNumber = string.Empty;
        //    Email = string.Empty;
        //}
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; }

        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "آدرس ایمیل نامعتبر می باشد")]
        public string Email { get; set; }
    }
}

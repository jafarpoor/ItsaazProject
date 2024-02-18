using Common.ErrorMassage;
using System.ComponentModel.DataAnnotations;
using LS = Common.ErrorMassage.ErrorMassageString;
namespace Application.Personal.DTO
{
    public class AddPersonViewModel
    {

        public AddPersonViewModel()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }

        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }  = DateTime.Now;   
        public string PhoneNumber { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "آدرس ایمیل نامعتبر می باشد")]
        public string Email { get; set; }
    }
}

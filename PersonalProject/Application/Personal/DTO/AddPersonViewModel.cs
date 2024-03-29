﻿using Common.ErrorMassage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public int Id { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید")]
        [DisplayName( "نام")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [DisplayName("نام خانوادگی")]
        public string Lastname { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime DateOfBirth { get; set; }  = DateTime.Now;
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "آدرس ایمیل نامعتبر می باشد")]
        public string Email { get; set; }
    }
}

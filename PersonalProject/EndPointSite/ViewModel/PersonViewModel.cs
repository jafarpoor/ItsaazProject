﻿namespace EndPointSite.ViewModel
{
    public class PersonViewModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PersianDateOfBirth { get; } = string.Empty;
    }
}

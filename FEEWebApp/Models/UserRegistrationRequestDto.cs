using System;
using System.ComponentModel.DataAnnotations;

namespace FEEWebApp.Models
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public string RoleId { get; set; }
        public string AcademicNumber { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

    }
}

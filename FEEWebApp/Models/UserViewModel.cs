using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public ApplicationUser UserData { get; set; }
        
    }
}

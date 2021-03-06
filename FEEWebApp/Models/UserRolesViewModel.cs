using System.Collections.Generic;

namespace FEEWebApp.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxViewModel> SelectedRoles { get; set; }
        public List<string> UserRoles { get; set; }
    }
}

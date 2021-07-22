using System.Collections.Generic;

namespace FEEWebApp.Models
{
    public class PermissionsFormViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<CheckBoxViewModel> SelectedClaims { get; set; }
        public List<string> UserClaims { get; set; }
    }
}

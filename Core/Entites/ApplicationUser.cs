using Microsoft.AspNetCore.Identity;

namespace Core.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
    }
}

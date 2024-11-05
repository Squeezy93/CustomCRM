using Microsoft.AspNetCore.Identity;

namespace CustomCRM.Domain.Users
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

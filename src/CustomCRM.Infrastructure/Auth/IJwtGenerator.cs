using CustomCRM.Domain.Users;

namespace CustomCRM.Infrastructure.Auth
{
    public interface IJwtGenerator
    {
        public string CreateToken(ApplicationUser user);
    }
}

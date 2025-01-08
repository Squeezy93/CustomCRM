using CustomCRM.Domain.Users;

namespace CustomCRM.Infrastructure.Auth.Jwt
{
    public interface IJwtGenerator
    {
        public string CreateToken(ApplicationUser user);
    }
}

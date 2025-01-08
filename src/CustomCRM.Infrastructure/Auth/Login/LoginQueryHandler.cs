using CustomCRM.Application.Users.Login;
using CustomCRM.Domain.Commons.Errors;
using CustomCRM.Domain.Users;
using CustomCRM.Infrastructure.Auth.Jwt;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CustomCRM.Infrastructure.Auth.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponce>>
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginQueryHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IJwtGenerator jwtGenerator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtGenerator = jwtGenerator ?? throw new ArgumentNullException(nameof(jwtGenerator));
        }

        public async Task<ErrorOr<LoginQueryResponce>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return UserErrors.UserNotFound;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new LoginQueryResponce(user.DisplayName, _jwtGenerator.CreateToken(user), user.Email);
            }

            return UserErrors.UserNotAuthorized;
        }
    }
}

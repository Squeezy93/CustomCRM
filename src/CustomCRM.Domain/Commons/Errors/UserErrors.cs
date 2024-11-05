using ErrorOr;

namespace CustomCRM.Domain.Commons.Errors
{
    public static class UserErrors
    {
        public static Error UserNotFound => Error.Validation("User", "User is not found");
        public static Error UserNotAuthorized => Error.Validation("User", "User is not Authorized");
    }
}

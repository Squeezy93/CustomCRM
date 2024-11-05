namespace CustomCRM.Application.Users.Login
{
    public record LoginQueryResponce(
        string DisplayName, 
        string Token, 
        string Email);
}

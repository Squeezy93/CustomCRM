using CustomCRM.Domain.Commons;

namespace CustomCRM.Application.Services.Responses
{
    public record ServiceResponse(
        Guid id, 
        string serviceType, 
        Difficult difficult, 
        Status status, 
        decimal amount, 
        Currency currency, 
        int quantity,
        string screenshotURL,
        string comment
        );   
}

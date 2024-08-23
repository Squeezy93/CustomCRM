using CustomCRM.Domain.Commons.Enums;
using CustomCRM.Domain.Commons.Enums.Services;

namespace CustomCRM.Application.Services.Responses
{
    public record ServiceResponse(
        Guid id, 
        string serviceType,
        DateTime created,
        DateTime modified,
        Difficult difficult, 
        Status status, 
        decimal amount, 
        Currency currency, 
        int quantity,
        string screenshotURL,
        string comment
        );   
}

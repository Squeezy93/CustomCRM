using CustomCRM.Api.Common.Constants;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace CustomCRM.Api.Common.Errors
{
    public class CustomCRMProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public CustomCRMProblemDetailsFactory(IOptions<ApiBehaviorOptions> options) 
        {
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, 
            int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode ??= 500;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            //enrich
            ApplyProblemDetails(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, 
            ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, 
            string? detail = null, string? instance = null)
        {
            if (modelStateDictionary == null)
            {
                throw new ArgumentNullException(nameof(modelStateDictionary));
            }

            statusCode ??= 400;

            var problemDetails = new ValidationProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            //enrich
            ApplyProblemDetails(httpContext, problemDetails, statusCode.Value);
            //if title is null can be possibly error, just in case

            return problemDetails;
        }

        private void ApplyProblemDetails(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData)) 
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Title;
            }

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            if (traceId != null)
            {
                problemDetails.Extensions[HttpConstants.TraceId] = traceId;
            }

            var errors = httpContext?.Items[HttpConstants.Errors] as List<Error>;

            if (errors != null)
            {
                problemDetails.Extensions[HttpConstants.Errors] = errors.Select(e => e.Code);
            }
        }
    }
}

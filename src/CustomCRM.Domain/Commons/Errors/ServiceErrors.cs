using ErrorOr;

namespace CustomCRM.Domain.Commons.Errors
{
    public static class ServiceErrors
    {
        public static Error ServiceNotFound => Error.Validation("Service", "Service not found");
        public static Error ServiceTypeIsNotValid => Error.Validation("Service.ServiceType", "Service Type is not valid");
        public static Error PriceIsNotValid => Error.Validation("Service.Price", "Price is not valid");
        public static Error ScreenshotIsNotValid => Error.Validation("Service.Screenshot", "Screenshot is not valid");
    }
}

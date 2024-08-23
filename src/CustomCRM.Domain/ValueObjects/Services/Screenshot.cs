namespace CustomCRM.Domain.ValueObjects.Services
{
    public class Screenshot
    {
        public string Url { get; private set; }
        private const string AllowedDomain = "imgur.com";

        private Screenshot(string screenshotURL)
        {
            Url = screenshotURL;
        }

        public static Screenshot? Create(string screenshotURL)
        {
            return new Screenshot(string.IsNullOrWhiteSpace(screenshotURL) ? string.Empty : screenshotURL);
        }

        public static Screenshot? Update(string screenshotURL)
        {
            ValidateUrl(screenshotURL);
            return new Screenshot(screenshotURL);
        }

        private static void ValidateUrl(string screenshotUrl)
        {
            if (string.IsNullOrWhiteSpace(screenshotUrl))
            {
                throw new ArgumentException("Screenshot URL cannot be null or empty", nameof(screenshotUrl));
            }

            if (!Uri.TryCreate(screenshotUrl, UriKind.Absolute, out Uri uriResult) ||
                !uriResult.Host.Contains(AllowedDomain))
            {
                throw new ArgumentException($"Allow screenshots only from {AllowedDomain}", nameof(screenshotUrl));
            }
        }
    }
}

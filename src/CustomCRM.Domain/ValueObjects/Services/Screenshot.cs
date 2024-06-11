namespace CustomCRM.Domain.ValueObjects.Services
{
    public class Screenshot
    {
        public string URL { get; private set; }

        private const string _allowedDomain = "imgur.com";

        private Screenshot(string screenshotURL)
        {
            URL = screenshotURL;
        }

        public static Screenshot Create(string screenshotURL)
        {            
            return new Screenshot(screenshotURL);
        }

        public static Screenshot Update(string screenshotURL)
        {
            if (!screenshotURL.Contains(_allowedDomain))
            {
                throw new ArgumentException($"Allow screenshots only from {_allowedDomain}", nameof(_allowedDomain));
            }
            return new Screenshot(screenshotURL);
        }
    }
}

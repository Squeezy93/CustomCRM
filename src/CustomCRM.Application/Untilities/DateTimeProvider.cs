namespace CustomCRM.Application.Untilities
{
    public static class DateTimeProvider
    {
        public static DateTime GetMoscowTime() => DateTime.UtcNow.AddHours(3);         
    }
}

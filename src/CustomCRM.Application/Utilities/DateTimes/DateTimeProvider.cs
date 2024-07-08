namespace CustomCRM.Application.Utilities.DateTimes
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetMoscowTime() => DateTime.UtcNow.AddHours(3);
    }
}

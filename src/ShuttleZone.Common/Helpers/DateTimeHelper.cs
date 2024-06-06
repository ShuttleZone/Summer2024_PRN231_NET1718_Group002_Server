namespace ShuttleZone.Common.Helpers;

public class DateTimeHelper
{
    public static TimeOnly FormatToTimeOnly(DateTime dateTime)
    {
        var formatedValue = dateTime.ToString("HH:mm");
        return TimeOnly.Parse(formatedValue);
    }
}
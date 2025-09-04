using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localTime = DateTime.Parse(appointmentDateDescription);
        TimeZoneInfo timeZone = GetTimeZoneInfo(location);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch(alertLevel) {
            case AlertLevel.Early:
                return appointment.AddMinutes(-1440d);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105d);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30d);
            }
            throw new ArgumentOutOfRangeException();
        }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZoneInfo(location);
        DateTime sevenDaysBefore = dt.AddDays(-7);

        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(sevenDaysBefore);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo culture = GetCultureInfo(location);
        if (DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        return new DateTime(1, 1, 1);
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
            System.Runtime.InteropServices.OSPlatform.Windows);

        string timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentException("Invalid location")
        };

        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }
    private static CultureInfo GetCultureInfo(Location location)
    {
        string cultureName = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => CultureInfo.InvariantCulture.Name
        };

        return new CultureInfo(cultureName);
    }
}

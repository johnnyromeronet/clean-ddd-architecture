using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Clean.DDD.Architecture.Domain.Enums;
using TimeZoneConverter;

namespace Clean.DDD.Architecture.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DateTimeExtension
    {
        public static string DateToString(this DateTime dt, string format, string? tzSourceId = TimeZoneEnum.UTC, string? tzTargetId = TimeZoneEnum.UTC)
        {
            return dt.ConvertDateTime(tzSourceId, tzTargetId).ToString(format);
        }

        public static DateTime StringToDate(this string dt, string format, string? tzSourceId = TimeZoneEnum.UTC, string? tzTargetId = TimeZoneEnum.UTC)
        {
            return DateTime.ParseExact(dt, format, CultureInfo.InvariantCulture).ConvertDateTime(tzSourceId, tzTargetId);
        }

        public static DateTime ConvertDateTime(this DateTime dt, string? tzSourceId = TimeZoneEnum.UTC, string? tzTargetId = TimeZoneEnum.UTC)
        {
            TimeZoneInfo tzTarget = GetTzInfo(tzTargetId!);
            TimeZoneInfo tzSource = GetTzInfo(tzSourceId!);
            return TimeZoneInfo.ConvertTime(dt, tzSource, tzTarget);
        }

        public static int GetHoursDiff(string tzId)
        {
            TimeZoneInfo tzInfo = GetTzInfo(tzId);
            var currentDt = TimeZoneInfo.ConvertTime(DateTime.Now, tzInfo);
            return (int)Math.Round((currentDt - DateTime.UtcNow).TotalHours);
        }

        private static TimeZoneInfo GetTzInfo(string tzId)
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(tzId);
            }
            catch (TimeZoneNotFoundException)
            {
                string tzAux = TZConvert.IanaToWindows(tzId);
                return TimeZoneInfo.FindSystemTimeZoneById(tzAux);
            }
        }
    }
}

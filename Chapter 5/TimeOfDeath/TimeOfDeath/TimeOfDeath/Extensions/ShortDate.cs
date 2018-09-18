using System;

namespace TimeOfDeath.Extensions
{
    public static class ShortDates
    {
        public static string ToShortDateString(this DateTime date)
        {
            return date.Date.ToString("dd/MM/YYYY");
        }

        public static string ToShortTimeString(this DateTime time)
        {
            return string.Format("{0}:{1}", time.Hour, time.Minute);
        }
    }
}

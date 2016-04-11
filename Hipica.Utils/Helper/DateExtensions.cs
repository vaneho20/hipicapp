using System;

namespace Hipica.Utils.Helper
{
    public static class DateExtensions
    {
        public static String UTCFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
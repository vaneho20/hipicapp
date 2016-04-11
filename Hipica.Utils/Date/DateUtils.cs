using NodaTime;
using System;

namespace Unne.Utils.Date
{
    public class DateUtils
    {
        private DateUtils()
        {
            // non instanceable
        }

        public static long? GetAgeExactInYears(DateTime? dateOfBirth)
        {
            long? age = null;
            if (dateOfBirth != null)
            {
                LocalDate start = new LocalDate(dateOfBirth.Value.Year, dateOfBirth.Value.Month, dateOfBirth.Value.Day);
                LocalDate end = new LocalDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                age = Period.Between(start, end, PeriodUnits.Years).Years;
            }
            return age;
        }
    }
}
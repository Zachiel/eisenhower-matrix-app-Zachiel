using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerCore
{
    internal class DateInput : Input
    {
        int dayToValidate;
        int monthToValidate;
        int yearToValidate;
        protected override bool IsInputValid()
        {
            return IsDateInputValid();
        }
        protected bool IsDateInputValid()
        {
            if (value.Length == 8)
            {
                string DayToValidate = value[0].ToString() + value[1].ToString();
                string MonthToValidate = value[3].ToString() + value[4].ToString();
                string YearToValidate = value[6].ToString() + value[7].ToString();
                bool IsDayValid = int.TryParse(DayToValidate, out int Day);
                bool IsMonthValid = int.TryParse(MonthToValidate, out int Month);
                bool IsYearValid = int.TryParse(YearToValidate, out int Year);
                dayToValidate = Day;
                monthToValidate = Month; 
                yearToValidate = Year;
                if (!IsDayValid || !IsMonthValid || !IsYearValid) return false;
                else if (AreDaysAndMonthsValid()) return true;
                return false;
            }
            return false;
        }
        private bool IsLeapYear() => ((2000 + yearToValidate) % 4 == 0 && (2000 + yearToValidate) % 100 != 0) || (2000 + yearToValidate) % 400 == 0;
        private bool AreDaysAndMonthsValid()
        {
            int februaryLength;
            if (IsLeapYear()) februaryLength = 29;
            else februaryLength = 28;
            List<int> ShortMonths = new List<int> { 4, 6, 9, 11 };
            List<int> LongMonths = new List<int> { 1, 3, 5, 7, 8, 10, 12 };
            if (monthToValidate > 0 && monthToValidate <= 12 && dayToValidate > 0)
            {
                if (ShortMonths.Contains(monthToValidate)) return dayToValidate <= 30;
                else if (LongMonths.Contains(monthToValidate)) return dayToValidate <= 31;
                else return dayToValidate <= februaryLength;
            }
            return false;
        }
        public DateInput(string message) : base(message)
        {
        }

        public DateTime GetConvertedValue() => DateTime.Parse(value);
    }
}

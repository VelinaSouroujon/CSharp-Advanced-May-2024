using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.DateModifier
{
    public static class DateModifier
    {
        public static int DaysDifference(string inputDate1, string inputDate2)
        {
            DateTime date1 = GetDate(inputDate1);
            DateTime date2 = GetDate(inputDate2);

            return Math.Abs((date2 - date1).Days);
        }
        private static DateTime GetDate(string date)
        {
            int[] dateInfo = date
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int year = dateInfo[0];
            int month = dateInfo[1];
            int day = dateInfo[2];

            return new DateTime(year, month, day);
        }
    }
}

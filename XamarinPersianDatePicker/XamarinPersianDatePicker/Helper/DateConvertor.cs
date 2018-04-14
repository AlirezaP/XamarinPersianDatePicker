using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPersianDatePicker.Helper
{
    class DateConvertor
    {
        public static Models.PersianDate ToPersianDate(int year,int month,int day)
        {
            return ToPersianDate(new DateTime(year, month, day));
        }
        public static Models.PersianDate ToPersianDate(DateTime date)
        {
            return Xamarin.Forms.DependencyService.Get<Interfaces.IDateConvertor>().ConvertToPersianDate(date);
        }

        public static DateTime ToDateTime(int year, int month, int day)
        {
            return ToDateTime(new Models.PersianDate(year, month, day));
        }
        public static DateTime ToDateTime(Models.PersianDate date)
        {
            return Xamarin.Forms.DependencyService.Get<Interfaces.IDateConvertor>().ConvertToDateTime(date);
        }

        public static long Ticks(Models.PersianDate date)
        {
            var temp = ToDateTime(date);
            return temp.Ticks;
        }
        public static int DayOfWeekend(Models.PersianDate date)
        {
            var temp = ToDateTime(date);
            return GetIndexOfDay(temp.DayOfWeek);
        }

        public static Models.PersianDate AddMonths(Models.PersianDate date, int number)
        {
            var temp = ToDateTime(date);
            var res = temp.AddMonths(number);

            return ToPersianDate(res);
        }

        public static Models.PersianDate AddDays(Models.PersianDate date, int number)
        {
            var t = ToDateTime(date);
            t = t.AddDays(number);

            var res = ToPersianDate(t);
            return res;
        }

        private static int GetIndexOfDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Saturday: return 0;
                case DayOfWeek.Sunday: return 1;
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;
            }
            return -1;
        }

        public static string GetPersianMonthName(int month)
        {
            switch (month)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهشت";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
            }

            return "";
        }
    }
}

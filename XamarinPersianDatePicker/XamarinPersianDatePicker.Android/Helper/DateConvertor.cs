using System;

using Xamarin.Forms;
using XamarinPersianDatePicker.Droid.Helper;
using XamarinPersianDatePicker.Models;

[assembly: Dependency(typeof(DateConvertor))]
namespace XamarinPersianDatePicker.Droid.Helper
{
   public class DateConvertor : XamarinPersianDatePicker.Interfaces.IDateConvertor
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        public PersianDate ConvertToPersianDate(DateTime date)
        {
            return new PersianDate
            {
                Year = pc.GetYear(date),
                Month = pc.GetMonth(date),
                Day = pc.GetDayOfMonth(date)
            };
        }

        public DateTime ConvertToDateTime(PersianDate date)
        {
            return pc.ToDateTime(date.Year, date.Month, date.Day,0,0,0,0);
        }
    }
}
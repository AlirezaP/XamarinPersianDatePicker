using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPersianDatePicker.Models
{
   public class PersianDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public PersianDate()
        {

        }

        public PersianDate(int year,int month,int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString()
        {
            return $"{Year}/{Month}/{Day}";
        }
    }
}

using System;
using XamarinPersianDatePicker.Models;

namespace XamarinPersianDatePicker.Interfaces
{
    public interface IDateConvertor
    {
        Models.PersianDate ConvertToPersianDate(DateTime date);
        DateTime ConvertToDateTime(PersianDate date);
    }
}

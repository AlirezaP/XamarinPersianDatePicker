using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinPersianDatePicker.Helper
{
   public class Dialogs
    {
        public async static Task<Models.PersianDate> GetDateWithPersianDatePicker()
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var modalPage = new Pages.PersianDatePicker();

            modalPage.Disappearing += (sender2, e2) =>
            {
                waitHandle.Set();
            };

            Service.NavigationService.PushModalPage(modalPage);

            await Task.Run(() => waitHandle.WaitOne());

            return new Models.PersianDate
            {
                Year = modalPage.SelectedYear,
                Month = modalPage.SelectedMonth,
                Day = modalPage.SelectedDay
            };
        }
    }
}

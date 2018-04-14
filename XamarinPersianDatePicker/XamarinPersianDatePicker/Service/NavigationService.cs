using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinPersianDatePicker.Service
{
   public class NavigationService
    {
        public static async void PushPage(Page obj)
        {
            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PushAsync(obj);
            }
        }

        public static async void PushModalPage(Page obj)
        {
            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PushModalAsync(obj);
            }
        }

        public static async void PopPage()
        {
            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PopAsync();
            }
        }

        public static async void PopModalPage()
        {
            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PopModalAsync();
            }
        }
    }
}

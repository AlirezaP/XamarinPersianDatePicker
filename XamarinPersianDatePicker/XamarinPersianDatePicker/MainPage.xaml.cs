using System;
using Xamarin.Forms;

namespace XamarinPersianDatePicker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void btnNextMonth_Clicked(object sender, EventArgs e)
        {
            var res = await Helper.Dialogs.GetDateWithPersianDatePicker();
            //res.Year
            //res.Month
            ///res.Day
            lblDate.Text = res.ToString();
        }

    }
}

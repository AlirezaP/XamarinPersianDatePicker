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
            lblDate.Text = res.ToString();
        }

    }
}

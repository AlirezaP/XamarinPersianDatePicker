using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPersianDatePicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersianDatePicker : ContentPage
    {
        private int _selectedDay;
        private int _selectedMonth;
        private int _selectedYear;

        public int SelectedDay { get { return _selectedDay; } }
        public int SelectedMonth { get { return _selectedMonth; } }
        public int SelectedYear { get { return _selectedYear; } }

        public event EventHandler<Models.PersianDate> Selected;

        private Command SelectDay;

        public PersianDatePicker()
        {
            InitializeComponent();
            FillYear();
            FirstInitial(null);

            yearPicker.SelectedIndexChanged += YearPicker_SelectedIndexChanged;
        }

        private void FirstInitial(DateTime? indexDate)
        {
            PickerGrid.Children.Clear();

            DateTime temp;

            if (indexDate.HasValue)
            {
                temp = indexDate.Value;
            }
            else
            {
                temp = DateTime.Now;
            }

            var temp1 = Helper.DateConvertor.ToPersianDate(temp);
            var tempPA = new Models.PersianDate(temp1.Year, temp1.Month, 1);

            var temp2 = Helper.DateConvertor.AddMonths(tempPA, 1);
            var tempPB = new Models.PersianDate(temp2.Year, temp2.Month, temp2.Day);

            _selectedYear = tempPA.Year;
            _selectedMonth = tempPA.Month;
            _selectedDay = tempPA.Day;

            yearPicker.SelectedItem = _selectedYear;

            currentMonthName.Text = Helper.DateConvertor.GetPersianMonthName(_selectedMonth);

            int indexX = 0;
            int indexY = 1;

            SelectDay = new Command((obj) =>
            {
                _selectedDay = (int)obj;
                Selected?.Invoke(this, new Models.PersianDate
                {
                    Year = _selectedYear,
                    Month = _selectedMonth,
                    Day = _selectedDay
                });

                Service.NavigationService.PopModalPage();
            });

            AddWeekendDays();

            while (true)
            {
                if (Helper.DateConvertor.Ticks(tempPA) >= Helper.DateConvertor.Ticks(tempPB))
                {
                    break;
                }

                if (Helper.DateConvertor.DayOfWeekend(tempPA) == indexX)
                {
                    PickerGrid.Children.Add(new Button()
                    {
                        Text = tempPA.Day.ToString(),
                        Command = SelectDay,
                        CommandParameter = tempPA.Day,

                    }, 6 - indexX, indexY);

                    tempPA = Helper.DateConvertor.AddDays(tempPA, 1);
                }
                else
                {
                    PickerGrid.Children.Add(new Button() { Text = "*", CommandParameter = "" }, 6 - indexX, indexY);
                }

                indexX++;

                if (indexX >= 7)
                {
                    indexX = 0;
                    indexY++;
                }
            }
        }

        private void FillYear()
        {
            var temp = Helper.DateConvertor.ToPersianDate(DateTime.Now).Year;
            temp -= 2;

            List<int> years = new List<int>();

            for (int i = temp; i < (temp + 5); i++)
            {
                years.Add(i);
            }

            yearPicker.ItemsSource = years;
        }

        private void YearPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstInitial(Helper.DateConvertor.ToDateTime((int)(((Picker)sender).SelectedItem), _selectedMonth, _selectedDay));
        }

        private void btnNextMonth_Clicked(object sender, EventArgs e)
        {
            if (_selectedMonth < 12)
            {
                _selectedMonth++;
            }

            FirstInitial(Helper.DateConvertor.ToDateTime(_selectedYear, _selectedMonth, _selectedDay));
        }

        private void btnPreMonth_Clicked(object sender, EventArgs e)
        {
            if (_selectedMonth > 1)
            {
                _selectedMonth--;
            }

            FirstInitial(Helper.DateConvertor.ToDateTime(_selectedYear, _selectedMonth, _selectedDay));
        }

        private void AddWeekendDays()
        {

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "شنبه"
            }, 6, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "یکشنبه"
            }, 5, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "دوشنبه"
            }, 4, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "سه شنبه"
            }, 3, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "چهارشنبه"
            }, 2, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "پنج شنبه"
            }, 1, 0);

            PickerGrid.Children.Add(new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "جمعه"
            }, 0, 0);
        }
    }
}
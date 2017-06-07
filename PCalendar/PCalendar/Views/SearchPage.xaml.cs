using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public ToolbarItem SearchToolbarItem { get { return SearchItem; } }

        public DateTime SearchDate
        {
            get
            {
                var yearText = PickerYear.Items[PickerYear.SelectedIndex];
                int year;
                if (int.TryParse(yearText, out year))
                {
                    year = year - 543;
                }
                else
                {
                    year = DateTime.Today.Year;
                }

                var month = PickerMonth.SelectedIndex + 1;

                return new DateTime(year, month, 1);
            }
        }

        public SearchPage(DateTime oldSearchDate)
        {
            InitializeComponent();

            var years = new List<string>();
            int startYear = oldSearchDate.Year - 1 + 543;
            for (int i = 0; i < 3; i++)
            {
                years.Add((startYear + i).ToString());
            }
            PickerYear.ItemsSource = years;
            PickerYear.SelectedIndex = years.IndexOf((oldSearchDate.Year + 543).ToString());

            PickerMonth.ItemsSource = Enum.GetNames(typeof(Enums.ThaiMonthOfYear)).ToList();
            PickerMonth.SelectedIndex = oldSearchDate.Month - 1;
        }
    }
}
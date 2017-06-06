using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleListPage : ContentPage
    {
        public ScheduleListPage()
        {
            InitializeComponent();

            var service = new ScheduleService();
            ScheduleList.ItemsSource = service.GetList(DateTime.Today);
        }

        async private void ScheduleList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = e.SelectedItem as ScheduleItem;
            await Navigation.PushAsync(new EditSchedulePage(item), true);
            ScheduleList.SelectedItem = null;
        }

        private void SearchToolbarItem_Activated(object sender, EventArgs e)
        {
            // TODO: search day
        }
    }

    public class ScheduleService
    {
        private List<ScheduleItem> _scheduleItems;
        private bool _isInit;

        public ScheduleService()
        {
            _isInit = true;
        }

        public List<ScheduleItem> GetList(DateTime dateCriteria)
        {
            if (_isInit)
            {
                _scheduleItems = new List<ScheduleItem>();
                var startDate = new DateTime(dateCriteria.Year, dateCriteria.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                for (var d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    _scheduleItems.Add(new ScheduleItem { ScheduleDate = d });
                }
                _isInit = false;
            }
            return _scheduleItems;
        }

        public void SaveItem(ScheduleItem item)
        {
            // TODO: switch case code 
            // for gen DescHospital
            _scheduleItems.Add(item);
        }
    }

    public class ScheduleItem
    {
        public string Day
        {
            get
            {
                string[] names = DateTimeFormatInfo.CurrentInfo.ShortestDayNames;
                return names[(int)ScheduleDate.DayOfWeek];
            }
        }

        public DateTime ScheduleDate { get; set; }

        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public bool IsPharmacy { get; set; }
        public TimeSpan? PharmacyFrom { get; set; }
        public TimeSpan? PharmacyTo { get; set; }

        public string DescHospital { get; set; }
        public string DescPharmacy
        {
            get
            {
                if (IsPharmacy)
                {
                    return $"{PharmacyFrom.Value:HH:mm}-{PharmacyTo.Value:HH:mm}";
                }
                return string.Empty;
            }
        }
    }
}
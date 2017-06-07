using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCalendar.Models;
using PCalendar.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleListPage : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private DateTime _searchDate;
        public DateTime SearchDate
        {
            get { return _searchDate; }
            set
            {
                if (value != _searchDate)
                {
                    _searchDate = value;
                    SetScheduleItem(value);
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<ScheduleItem> _scheduleItems;

        public ScheduleListPage()
        {
            InitializeComponent();
            BindingContext = this;

            _scheduleItems = new ObservableCollection<ScheduleItem>();
            ScheduleList.ItemsSource = _scheduleItems;

            SearchDate = DateTime.Today;
        }

        public void SetScheduleItem(DateTime dateTime)
        {
            var service = new ScheduleService();
            var items = service.GetList(dateTime);
            foreach (var item in items)
            {
                _scheduleItems.Add(item);
            }
        }

        async private void ScheduleList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = e.SelectedItem as ScheduleItem;
            await Navigation.PushAsync(new EditSchedulePage(item), true);
            ScheduleList.SelectedItem = null;
        }

        async private void SearchToolbarItem_Activated(object sender, EventArgs e)
        {
            var searchPage = new SearchPage();
            await Navigation.PushAsync(searchPage, true);
        }
    }
}
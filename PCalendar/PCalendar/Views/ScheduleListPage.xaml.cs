using PCalendar.Models;
using PCalendar.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<ScheduleItem> _scheduleItems;

        private IScheduleService _service;

        public ScheduleListPage()
        {
            InitializeComponent();
            BindingContext = this;

            _scheduleItems = new ObservableCollection<ScheduleItem>();
            _service = TinyIoC.TinyIoCContainer.Current.Resolve<IScheduleService>();

            ScheduleList.ItemsSource = _scheduleItems;

            SearchScheduleItem(DateTime.Today);
        }

        public void SearchScheduleItem(DateTime dateTime)
        {
            _scheduleItems.Clear();
            var items = _service.GetList(dateTime);
            foreach (var item in items)
            {
                _scheduleItems.Add(item);
            }
            SearchDate = dateTime;
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
            var searchPage = new SearchPage(SearchDate);
            searchPage.SearchToolbarItem.Clicked += async (src, arg) =>
            {
                this.SearchScheduleItem(searchPage.SearchDate);
                await Navigation.PopAsync(true);
            };

            await Navigation.PushAsync(searchPage, true);
        }
    }
}
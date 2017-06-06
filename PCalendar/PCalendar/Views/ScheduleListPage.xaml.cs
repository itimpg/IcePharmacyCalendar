using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCalendar.Models;
using PCalendar.Services;

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
}
using PCalendar.Services.Interfaces;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeListPage : ContentPage
    {
        public ListView Codes { get { return CodeList; } }

        private IScheduleService _service;

        public CodeListPage()
        {
            InitializeComponent();
            _service = TinyIoCContainer.Current.Resolve<IScheduleService>();

            List<string> itemsSource = _service.GetCodeList();
            CodeList.ItemsSource = itemsSource;

            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                SearchBar.HeightRequest = 40.0;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<string> itemsSource = _service.GetCodeList(e.NewTextValue);
            CodeList.ItemsSource = itemsSource;
        }
    }
}
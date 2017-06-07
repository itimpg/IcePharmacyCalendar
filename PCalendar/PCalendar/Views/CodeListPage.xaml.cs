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
        }

        protected override void OnAppearing()
        {
            List<string> itemsSource = _service.GetCodeList();
            CodeList.ItemsSource = itemsSource;
            base.OnAppearing();
        }
    }
}
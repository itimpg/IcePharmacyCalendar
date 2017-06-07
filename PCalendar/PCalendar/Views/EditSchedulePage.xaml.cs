using PCalendar.Models;
using PCalendar.Services.Interfaces;
using System;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSchedulePage : ContentPage
    {
        public ScheduleItem Item { get; private set; }
        private IScheduleService _service;

        public EditSchedulePage(ScheduleItem item)
        {
            InitializeComponent();
            _service = TinyIoCContainer.Current.Resolve<IScheduleService>();

            Item = item;
            BindingContext = this;
            SetScreenValue();
        }

        private void SetScreenValue()
        {
            Code1.Code = Item.Code1 ?? "X";
            Code2.Code = Item.Code2 ?? "X";
            SwitchIsPharmacy.On = Item.IsPharmacy;
            TimeFrom.Time = Item.PharmacyFrom;
            TimeTo.Time = Item.PharmacyTo;
        }

        async private void DoneToolbarItem_Activated(object sender, EventArgs e)
        {
            Item.Code1 = Code1.Code;
            Item.Code2 = Code2.Code;
            Item.IsPharmacy = SwitchIsPharmacy.On;
            Item.PharmacyFrom = TimeFrom.Time;
            Item.PharmacyTo = TimeTo.Time;

            var descList = new List<string>();
            descList.Add(_service.GetTimeByCode(Item.Code1));
            descList.Add(_service.GetTimeByCode(Item.Code2));

            if (Item.IsPharmacy)
            {
                descList.Add($"{Item.PharmacyFrom.ToString(@"hh\:mm")}-{Item.PharmacyTo.ToString(@"hh\:mm")}");
            }

            Item.Description = string.Join(", ", descList);

            _service.SaveItem(Item);
            await Navigation.PopAsync(true);
        }

        async private void Code1_Tapped(object sender, EventArgs e)
        {
            var page = new CodeListPage();
            page.Codes.ItemSelected += async (src, arg) =>
            {
                Code1.Code = arg.SelectedItem.ToString();
                await Navigation.PopAsync(true);
            };
            await Navigation.PushAsync(page, true);
        }

        async private void Code2_Tapped(object sender, EventArgs e)
        {
            var page = new CodeListPage();
            page.Codes.ItemSelected += async (src, arg) =>
            {
                Code2.Code = arg.SelectedItem.ToString();
                await Navigation.PopAsync(true);
            };
            await Navigation.PushAsync(page, true);
        }
    }
}
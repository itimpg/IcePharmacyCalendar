using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCalendar.Models;
using System;
using System.Collections.Generic;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSchedulePage : ContentPage
    {
        public ScheduleItem Item { get; private set; }

        public EditSchedulePage() { }

        public EditSchedulePage(ScheduleItem item)
        {
            InitializeComponent();
            Item = item;
            BindingContext = this;

            Code1.Code = item.Code1 ?? "None";
            Code2.Code = item.Code2 ?? "None";
            SwitchIsPharmacy.On = item.IsPharmacy;
            TimeFrom.Time = item.PharmacyFrom;
            TimeTo.Time = item.PharmacyTo;
        }

        async private void DoneToolbarItem_Activated(object sender, EventArgs e)
        {
            Item.Code1 = Code1.Code;
            Item.Code2 = Code2.Code;
            Item.IsPharmacy = SwitchIsPharmacy.On;
            Item.PharmacyFrom = TimeFrom.Time;
            Item.PharmacyTo = TimeTo.Time;

            var descList = new List<string>();
            if (hospitalCodes.ContainsKey(Item.Code1))
            {
                descList.Add(hospitalCodes[Item.Code1]);
            }

            if (hospitalCodes.ContainsKey(Item.Code2))
            {
                descList.Add(hospitalCodes[Item.Code2]);
            }

            if (Item.IsPharmacy)
            {
                descList.Add($"{Item.PharmacyFrom.ToString(@"hh\:mm")}-{Item.PharmacyTo.ToString(@"hh\:mm")}");
            }

            Item.Description = string.Join(", ", descList);

            await Navigation.PopAsync(true);
        }

        public Dictionary<string, string> hospitalCodes = new Dictionary<string, string>
        {
            { "D", "08.00-16.00" },
            { "D1", "08.00-17.00" },
            { "D3", "08.00-20.00" },
            { "D5", "08.00-18.00" },
            { "F1", "09.00-17.00" },
            { "F5", "09.00-21.00" },
            { "G1", "10.00-18.00" },
            { "G3", "10.00-20.00" },
            { "G4", "10.00-22.00" },
            { "B", "07.00-15.00" },
            { "K", "15.00-23.00" },
            { "O", "23.00-07.00" },
            { "X", "None" },
        };

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
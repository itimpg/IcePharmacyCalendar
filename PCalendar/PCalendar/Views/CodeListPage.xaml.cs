﻿using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeListPage : ContentPage
    {
        public ListView Codes { get { return CodeList; } }

        public CodeListPage()
        {
            InitializeComponent();

            List<string> itemsSource = hospitalCodes.Select(x => x.Key).ToList();
            itemsSource.Insert(0, "None");

            CodeList.ItemsSource = itemsSource;
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
    }
}
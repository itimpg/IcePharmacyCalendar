using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create("Label", typeof(string), typeof(TimeCell));

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create("Time", typeof(TimeSpan), typeof(TimeCell), TimeSpan.Zero);

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public TimeCell()
        {
            this.Tapped += (s, e) =>
            {
                TimePicker.Focus();
            };
            InitializeComponent();
            BindingContext = this;
        }
    }
}
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCalendar.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create("Label", typeof(string), typeof(TimeCell));

        public static readonly BindableProperty CodeProperty =
          BindableProperty.Create("Code", typeof(string), typeof(TimeCell));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public CodeCell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
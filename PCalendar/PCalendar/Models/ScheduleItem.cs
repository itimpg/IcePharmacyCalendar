using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PCalendar.Models
{
    public class ScheduleItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public DateTime ScheduleDate { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public bool IsPharmacy { get; set; }
        public TimeSpan PharmacyFrom { get; set; }
        public TimeSpan PharmacyTo { get; set; }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != this._description)
                {
                    this._description = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

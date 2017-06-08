using SQLite;
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

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public bool IsPharmacy { get; set; }
        public TimeSpan PharmacyFrom { get; set; }
        public TimeSpan PharmacyTo { get; set; }

        private string _hospitalTime;
        public string HospitalTime
        {
            get
            {
                return _hospitalTime;
            }
            set
            {
                if (value != this._hospitalTime)
                {
                    this._hospitalTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _pharmacyTime;
        public string PharmacyTime
        {
            get
            {
                return _pharmacyTime;
            }
            set
            {
                if (value != this._pharmacyTime)
                {
                    this._pharmacyTime = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

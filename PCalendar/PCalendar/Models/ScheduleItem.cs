using SQLite;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PCalendar.Models
{
    public class ScheduleItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
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

        private string _code1;
        public string Code1
        {
            get { return _code1; }
            set
            {
                if (value != this._code1)
                {
                    _code1 = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("CodeText");
                }
            }
        }

        private string _code2;
        public string Code2
        {
            get { return _code2; }
            set
            {
                if (value != this._code2)
                {
                    _code2 = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("CodeText");
                }
            }
        }

        public string CodeText
        {
            get
            {
                string[] codes = new string[] { _code1, _code2 };
                var workingCode = codes.Where(x => x.ToLower() != "x");
                return workingCode.Count() > 0 ?
                    string.Join(string.Empty, workingCode) :
                    "X";
            }
        }
    }
}

using System;
using System.Globalization;

namespace PCalendar.Models
{
    public class ScheduleItem
    {
        public string Day
        {
            get
            {
                string[] names = DateTimeFormatInfo.CurrentInfo.ShortestDayNames;
                return names[(int)ScheduleDate.DayOfWeek];
            }
        }

        public DateTime ScheduleDate { get; set; }

        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public bool IsPharmacy { get; set; }
        public TimeSpan PharmacyFrom { get; set; }
        public TimeSpan PharmacyTo { get; set; }

        public string Description { get; set; }
    }
}

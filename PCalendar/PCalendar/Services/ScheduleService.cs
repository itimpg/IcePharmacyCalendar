using System;
using System.Collections.Generic;
using System.Text;
using PCalendar.Models;
using PCalendar.Services.Interfaces;

namespace PCalendar.Services
{
    public class ScheduleService : IScheduleService
    {
        private List<ScheduleItem> _scheduleItems;
        private bool _isInit;

        public ScheduleService()
        {
            _isInit = true;
        }

        public List<ScheduleItem> GetList(DateTime dateCriteria)
        {
            if (_isInit)
            {
                _scheduleItems = new List<ScheduleItem>();
                var startDate = new DateTime(dateCriteria.Year, dateCriteria.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                for (var d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    _scheduleItems.Add(new ScheduleItem { ScheduleDate = d });
                }
                _isInit = false;
            }
            return _scheduleItems;
        }

        public void SaveItem(ScheduleItem item)
        {
            // TODO: switch case code 
            // for gen DescHospital
            _scheduleItems.Add(item);
        }
    }
}

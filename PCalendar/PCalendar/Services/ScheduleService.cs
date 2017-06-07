using PCalendar.Models;
using PCalendar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCalendar.Services
{
    public class ScheduleService : IScheduleService
    {
        private List<ScheduleItem> _scheduleItems;

        public ScheduleService()
        {
        }

        public List<ScheduleItem> GetList(DateTime dateCriteria)
        {
            _scheduleItems = new List<ScheduleItem>();
            var startDate = new DateTime(dateCriteria.Year, dateCriteria.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            for (var d = startDate; d <= endDate; d = d.AddDays(1))
            {
                _scheduleItems.Add(new ScheduleItem { ScheduleDate = d });
            }
            return _scheduleItems;
        }

        public void SaveItem(ScheduleItem item)
        {
            // TODO: switch case code 
            // for gen DescHospital
            _scheduleItems.Add(item);
        }

        public string GetTimeByCode(string code)
        {
            if (hospitalCodes.ContainsKey(code))
            {
                return hospitalCodes[code];
            }
            return string.Empty;
        }

        public List<string> GetCodeList()
        {
            return hospitalCodes.Select(x => x.Key).ToList();
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
            { "X", "" },
        };
    }
}

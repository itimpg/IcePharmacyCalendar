using System;
using System.Collections.Generic;
using System.Text;
using PCalendar.Models;

namespace PCalendar.Services.Interfaces
{
    public interface IScheduleService
    {
        List<ScheduleItem> GetList(DateTime dateCriteria);
        void SaveItem(ScheduleItem item);
    }
}

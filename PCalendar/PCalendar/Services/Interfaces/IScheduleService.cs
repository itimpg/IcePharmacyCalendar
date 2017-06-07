using PCalendar.Models;
using System;
using System.Collections.Generic;

namespace PCalendar.Services.Interfaces
{
    public interface IScheduleService
    {
        List<ScheduleItem> GetList(DateTime dateCriteria);
        void SaveItem(ScheduleItem item);
        string GetTimeByCode(string code);
        List<string> GetCodeList();
    }
}

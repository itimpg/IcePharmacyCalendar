using PCalendar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCalendar.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleItem>> GetListAsync(DateTime dateCriteria);
        Task SaveScheduleItemAsync(ScheduleItem item);
        string GetTimeByCode(string code);
        List<string> GetCodeList();
    }
}

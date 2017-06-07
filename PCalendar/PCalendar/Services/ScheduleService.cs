using PCalendar.Models;
using PCalendar.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCalendar.Services
{
    public class ScheduleService : IScheduleService
    {
        private SQLiteAsyncConnection _connection;

        public ScheduleService(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<ScheduleItem>();
        }

        public async Task<List<ScheduleItem>> GetListAsync(DateTime dateCriteria)
        {
            try
            {
                var monthSource = new List<ScheduleItem>();
                var startDate = new DateTime(dateCriteria.Year, dateCriteria.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                for (var d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    monthSource.Add(new ScheduleItem { ScheduleDate = d, Code1 = "X", Code2 = "X" });
                }
                
                var dbSource = await _connection.Table<ScheduleItem>()
                    .Where(x => x.ScheduleDate >= startDate && x.ScheduleDate <= endDate)
                    .ToListAsync();

                var leftJoin = from a in monthSource
                               join b in dbSource on a.ScheduleDate equals b.ScheduleDate into lj
                               from c in lj.DefaultIfEmpty()
                               select c == null ? a : c;

                return leftJoin.ToList();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                throw;
            }
        }

        public async Task SaveScheduleItemAsync(ScheduleItem item)
        {
            if (item.Id == 0)
            {
                await _connection.InsertAsync(item);
            }
            else
            {
                await _connection.UpdateAsync(item);
            }
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

using PCalendar.Services.Interfaces;
using System;
using SQLite;
using System.IO;

namespace PCalendar.Services
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MyDb.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

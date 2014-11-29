using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTag.Helper
{
    public static class DB
    {
        private static string dbPath = @"Data Source=D:\Code\DocTag\DocTag\DocTag\bin\Debug\db.db;";

        public static string GetConnStr()
        {
            return dbPath;
        }
    }
}

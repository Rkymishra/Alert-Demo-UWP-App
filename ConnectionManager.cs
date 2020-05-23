using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert
{
    public static class ConnectionManager
    {
        private static string connectionString = @"Data Source=MSI;Initial Catalog=DailyRoutineAlert;Persist Security Info=True;User ID=rkymishra;Password=adminadmin";
        public static string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}

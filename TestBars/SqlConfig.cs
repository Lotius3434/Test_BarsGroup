using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars
{
    public static class SqlConfig
    {
        public static readonly string sqlquery = @"select datname,  pg_database_size(datname)
                     from pg_database;";
    }
}

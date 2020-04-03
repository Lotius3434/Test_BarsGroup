using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    public interface IDbObj
    {
        string name { get; set; }
        string size { get; set; }
        string updateDate { get; set; }
    }
}

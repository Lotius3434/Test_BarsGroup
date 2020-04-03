using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    interface IServerObj
    {
        string NameServer { get; set; }
        IList<IDbObj> DataBases { get; set; }
    }
}

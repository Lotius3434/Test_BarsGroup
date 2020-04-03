using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IServerObj
    {
        string NameServer { get; set; }
        IList<IDbObj> DataBases { get; set; }
    }
}

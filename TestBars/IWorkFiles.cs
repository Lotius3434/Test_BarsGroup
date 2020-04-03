using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars
{
    public interface IWorkFiles
    {
        void WriteFileTxt(IList<IServerObj> servers);
    }
}

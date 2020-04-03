using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars
{
    public interface IWorkFiles
    {
        void WriteFileTxt(IList<IServerObj> servers);
    }
}

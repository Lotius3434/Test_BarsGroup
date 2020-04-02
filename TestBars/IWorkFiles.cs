using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.UpdateWorkServersPostgreSql;

namespace TestBars
{
    interface IWorkFiles
    {
        void WriteFileTxt(IList<IServerObj> servers);
    }
}

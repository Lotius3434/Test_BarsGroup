using System;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    interface IServer
    {
        void OpenConnection();
        void CloseConnection();
        string GetNameServer();
        List<IList<Object>> GetBasesandSizes();

    }
}

using System;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    abstract class AbstractServers : IServer
    {
        private readonly string Name;
        

        public virtual void OpenConnection()
        {
            
        }
        public virtual void CloseConnection()
        {
            
        }
        public virtual string GetNameServer()
        {
            return Name;
        }
        public virtual List<IList<Object>> GetBasesandSizes()
        {
            List<IList<Object>> table = new List<IList<Object>>();

            

            return table;
        }
    }
}

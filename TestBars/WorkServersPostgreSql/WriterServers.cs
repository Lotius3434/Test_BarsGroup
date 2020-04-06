using Castle.Windsor;
using Npgsql;
using System;
using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    /// <summary>
    /// Класс сортирует данные, полученные из DB, по объектам для хранения.
    /// </summary>
    /// <inheritdoc/>
    public class WriterServers : IWriterServers
    {
        WindsorContainer container;
        IServerObj server;
        IList<IDbObj> ListdataBases;
        
        public void CreateServerObj(string ServerName)
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            server = container.Resolve<IServerObj>();
            server.NameServer = ServerName;
            ListdataBases = new List<IDbObj>();
        }

        public void WriteServerObjs(string nameDb, string sizeDb, string updateDateDb)
        {
            IDbObj dataObj = container.Resolve<IDbObj>();
            dataObj.name = nameDb;
            dataObj.size = sizeDb;
            dataObj.updateDate = updateDateDb;
            ListdataBases.Add(dataObj);
        }
        public IServerObj GetServerObj()
        {
            server.DataBases = ListdataBases;
            return server;
        }
    }
}

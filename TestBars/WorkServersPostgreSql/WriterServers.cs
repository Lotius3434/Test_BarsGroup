using Castle.Windsor;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    class WriterServers : IWriterServers
    {
        IList<IServerObj> ListServerObjs = new List<IServerObj>();
        
        

        public IList<IServerObj> WriteServerObjs(IDictionary<string, NpgsqlDataReader> DictDataReaders)
        {
            
            if (DictDataReaders.Count != 0)
            {
                var container = new WindsorContainer();
                container.Install(new ConfigurationCastleWindsor());
                foreach (var _DictDataReader in DictDataReaders)
                {
                    IServerObj server = container.Resolve<IServerObj>();
                    server.NameServer = _DictDataReader.Key;
                    IList<IDbObj> dataBases = new List<IDbObj>();

                    while (_DictDataReader.Value.Read())
                    {
                        IDbObj db = container.Resolve<IDbObj>();
                        db.name = _DictDataReader.Value.GetString(0);
                        db.size = Converter.CalculateBytetoGB(_DictDataReader.Value.GetInt64(1));
                        db.updateDate = DateTime.Now.ToString("dd.MM.yyyy");
                        dataBases.Add(db);
                    }

                    server.DataBases = dataBases;
                    ListServerObjs.Add(server);

                }
            }
            
            
            return ListServerObjs;
        }
    }
}

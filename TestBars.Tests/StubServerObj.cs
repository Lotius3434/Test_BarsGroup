using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.Tests
{
    public class StubServerObj : IServerObj
    {
        private string _NameServer = "LocalServer";
        private IList<IDbObj> dbObjs = new List<IDbObj>();
        WindsorContainer container;
        public StubServerObj()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            IDbObj db = container.Resolve<IDbObj>();
            dbObjs.Add(db);
        }
        public string NameServer
        {
            get
            {
                return _NameServer;
            }
            set
            {
                if (_NameServer == null)
                    _NameServer = value;

            }
        }
        public IList<IDbObj> DataBases
        {
            get
            {
                return dbObjs;
            }
            set
            {
                if (dbObjs == null)
                {
                    dbObjs = value;
                }

            }
        }
    }
}

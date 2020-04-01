using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.UpdateWorkServersPostgreSql;

namespace TestBars
{
    class ConfigurationCastleWindsor : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbObj>().ImplementedBy<DbObj>().LifestyleTransient());
            container.Register(Component.For<IServerObj>().ImplementedBy<ServerObj>().LifestyleTransient());

            container.Register(Component.For<IParseConfiguration>().ImplementedBy<ParseConfiguration>());
            container.Register(Component.For<IConnectionDb>().ImplementedBy<ConnectionDb>());
            container.Register(Component.For<IWriterServers>().ImplementedBy<WriterServers>());
            
        }
    }
}

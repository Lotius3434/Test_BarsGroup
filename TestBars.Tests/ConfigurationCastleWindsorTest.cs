using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestBars.Tests;
using TestBars.WorkProvider;
using TestBars.WorkServersPostgreSql;
using TestBars.WorkSheetsGoogle;

namespace TestBars
{
    public class ConfigurationCastleWindsorTest : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbObj>().ImplementedBy<StubDbObj>().LifestyleTransient());
            container.Register(Component.For<IServerObj>().ImplementedBy<StubServerObj>().LifestyleTransient());
            container.Register(Component.For<IManagerConnectionDb>().ImplementedBy<ManagerConnectionDb>());
            container.Register(Component.For<IWriterServers>().ImplementedBy<WriterServers>());
            container.Register(Component.For<IUserAuthentication>().ImplementedBy<UserAuthentication>());
            container.Register(Component.For<IServices>().ImplementedBy<Services>());
            container.Register(Component.For<IWorkFiles>().ImplementedBy<WorkFiles>());
            container.Register(Component.For<IDrives>().ImplementedBy<StubDrives>());
            container.Register(Component.For<IProvider>().ImplementedBy<MockProviderNpgsql>());
            container.Register(Component.For<IParseConfiguration>().ImplementedBy<StubParseConfiguration>());
        }
    }
}

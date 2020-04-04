using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestBars.WorkProvider;
using TestBars.WorkServersPostgreSql;
using TestBars.WorkSheetsGoogle;

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

            container.Register(Component.For<IUserAuthentication>().ImplementedBy<UserAuthentication>());
            container.Register(Component.For<IServices>().ImplementedBy<Services>());
            container.Register(Component.For<ISpreasheet>().ImplementedBy<Spreasheet>());
            container.Register(Component.For<ISearchSpreadsheets>().ImplementedBy<SearchSpreadsheets>());
            container.Register(Component.For<IWorkFiles>().ImplementedBy<WorkFiles>());
            container.Register(Component.For<IProvider>().ImplementedBy<ProviderNpgsql>());
        }
    }
}

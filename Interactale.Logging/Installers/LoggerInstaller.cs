using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Interactale.Logging.Factories;

namespace Interactale.Logging.Installers
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogLoggerFactory>());
            container.Register(Component.For<IFileLogger>().ImplementedBy<FileLogger>());
        }
    }
}

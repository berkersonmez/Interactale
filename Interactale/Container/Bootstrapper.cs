using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Interactale.Container.Factories;
using Interactale.Logging.Installers;
using Interactale.Repository.Installers;

namespace Interactale.Container
{
    public class Bootstrapper
    {
        private static IWindsorContainer Container { get; set; }

        public static void BootstrapContainer()
        {
            Container = new WindsorContainer()
                .Install(FromAssembly.This())
                .Install(new LoggerInstaller())
                .Install(new PersistenceInstaller());
            var controllerFactory = new WindsorControllerFactory(Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
         
    }
}

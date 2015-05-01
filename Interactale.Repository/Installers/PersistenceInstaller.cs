using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Interactale.Repository.Facilities;
using Interactale.Repository.Interceptors;

namespace Interactale.Repository.Installers
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<PersistenceFacility>();
            container.Register(Component.For<ITaleRepository>().ImplementedBy<TaleRepository>()
                .Interceptors(InterceptorReference.ForType<TransactionInterceptor>()).Last, Component.For<TransactionInterceptor>());
        }
    }
}

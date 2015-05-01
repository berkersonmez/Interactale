using Castle.DynamicProxy;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Interactale.Repository.Interceptors
{
    public class TransactionInterceptor : IInterceptor
    {
        public ISession Session { get; private set; }

        public TransactionInterceptor(ISession session)
        {
            this.Session = session;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var transaction = Session.BeginTransaction())
            {
                invocation.Proceed();
                transaction.Commit();
            }
        }
    }
}

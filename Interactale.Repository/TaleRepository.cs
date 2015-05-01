using System.Collections.Generic;
using System.Linq;
using Interactale.Domain.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Interactale.Repository
{
    public class TaleRepository : ITaleRepository
    {
        public ISession Session { get; private set; }

        public TaleRepository(ISession session)
        {
            this.Session = session;
        }

        public List<Tale> GetTales()
        {
            return this.Session.Query<Tale>().ToList();
        }
    }
}

using System.Collections.Generic;
using Interactale.Domain.Entities;
using NHibernate.Mapping;

namespace Interactale.Repository
{
    public interface ITaleRepository
    {
        List<Tale> GetTales();
    }
}

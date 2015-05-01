using FluentNHibernate.Mapping;
using Interactale.Domain.Entities;

namespace Interactale.Domain.Maps
{
    public class TaleMap : ClassMap<Tale>
    {
        public TaleMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}

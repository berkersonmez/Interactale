using System;
using Castle.Core.Internal;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Interactale.Domain.Entities;
using Interactale.Domain.Maps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Interactale.Repository.Facilities
{
    public class PersistenceFacility : AbstractFacility
    {

        //protected virtual AutoPersistenceModel CreateMappingModel()
        //{
        //    var m = AutoMap.Assembly(typeof(EntityBase).Assembly)
        //        .Conventions.Add<CascadeConvention>()
        //        .Where(IsDomainEntity)
        //        .OverrideAll(ShouldIgnoreProperty)
        //        .IgnoreBase<EntityBase>();

        //    return m;
        //}

        protected override void Init()
        {
            var config = BuildDatabaseConfiguration();

            Kernel.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest()
                );
        }

        //protected virtual bool IsDomainEntity(Type t)
        //{
        //    return typeof(EntityBase).IsAssignableFrom(t);
        //}

        protected virtual IPersistenceConfigurer SetupDatabase()
        {
            return MsSqlConfiguration.MsSql2012
                .UseOuterJoin()
                .ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString"))
                .ShowSql();
        }

        private Configuration BuildDatabaseConfiguration()
        {
            return Fluently.Configure()
                .Database(SetupDatabase)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaleMap>())
                .BuildConfiguration();
        }

        //private void ShouldIgnoreProperty(IPropertyIgnorer property)
        //{
        //    property.IgnoreProperties(p => p.MemberInfo.HasAttribute<DoNotMapAttribute>());
        //}
    }
}

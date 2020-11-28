using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SoftwareBlog.Core.DataAccess.NHibernate;

namespace SoftwareBlog.Northwind.DataAccess.Concrete.NHibernate.Helper
{
   public class SqlServerHelper:NHibernateHelper
    {
        protected override ISessionFactory initializeFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>
                    c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();
        }
    }
}

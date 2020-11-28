using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace SoftwareBlog.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = initializeFactory()); }
        }

        protected abstract ISessionFactory initializeFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

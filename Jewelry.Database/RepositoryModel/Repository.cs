namespace Jewelry.Database.RepositoryModel
{
    using System.Collections.Generic;
    using Jewelry.Database.Nhibernate;
    using NHibernate;
    using NHibernate.Criterion;

    public class Repository<T> : IRepository<T>
    {
        public T GetById(int Id)
        {
            T item;
            using (var session = GetSession())
            {
                item = session.Get<T>(Id);
            }
            return item;
        }

        public void InsertOrUpdate(T item)
        {
            using (var session = GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
        }

        public void Delete(T item)
        {
            using (var session = GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }
        public IList<T> GetList()
        {
            using (var session = GetSession())
            {
                return session
                    .CreateCriteria(typeof(T))
                    .List<T>();
            }
        }

        public IEnumerable<T> ListByProperty(string propertyName, object value)
        {
            using (var session = GetSession())
            {
                return session
                    .CreateCriteria(typeof(T))
                    .Add(Restrictions.Eq(propertyName, value))
                    .List<T>();
            }
        }

        private ISession GetSession()
        {
            return NHibernateHelper.OpenSession();
        }
        private void DisposeSession(ISession session)
        {
            session.Dispose();
        }
    }
}

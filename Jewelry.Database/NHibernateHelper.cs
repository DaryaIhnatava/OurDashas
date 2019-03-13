using NHibernate;
using NHibernate.Cfg;

namespace Jewelry.Database
{
    public class NHibernateHelper
    {
        public static NHibernate.ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurePath = @"hibernate.cfg.xml";
            configuration.Configure(configurePath);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            //Позволяет Nhibernate самому создавать в БД таблицу и поля к ним. 
           // new SchemaUpdate(configuration).Execute(true, true);
            return sessionFactory.OpenSession();
        }
    }
}


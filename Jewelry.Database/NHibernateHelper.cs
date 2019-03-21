namespace Jewelry.Database
{
    #region Usings
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using System.Reflection;
    #endregion

    public class NHibernateHelper
    {
        public static NHibernate.ISession OpenSession()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x => {
                x.ConnectionString = @"Data Source=EPBYMOGW0027\SQLEXPRESS;Initial Catalog=JewelryStore;User ID=JUser;Password=J_User123;"; 
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}


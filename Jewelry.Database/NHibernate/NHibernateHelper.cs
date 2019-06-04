namespace Jewelry.Database.Nhibernate
{
    using System.Reflection;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.Attributes;

    public class NHibernateHelper
    {
        public static NHibernate.ISession OpenSession()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x => 
            {
                x.ConnectionString = @"Data Source=EPBYMOGW0027\SQLEXPRESS;Initial Catalog=Jewelry;User ID=JUser;Password=Query_123;";
                //x.ConnectionString = @"Data Source=LAPTOP-868QL38T\SQLEXPRESS;Initial Catalog=training;User ID=JUser;Password=qwerty123;"; 
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
            });
            HbmSerializer.Default.Validate = true;
            var stream = HbmSerializer.Default.Serialize(Assembly.GetExecutingAssembly());
            cfg.AddInputStream(stream);
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}

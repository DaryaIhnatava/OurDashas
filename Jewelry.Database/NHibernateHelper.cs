// <copyright file="NHibernateHelper.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database
{
    #region Usings
    using System.Reflection;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.Attributes;
    #endregion

    /// <summary>
    /// NHibernate Helper
    /// </summary>
    public class NHibernateHelper
    {
        /// <summary>
        /// Opens the session.
        /// </summary>
        /// <returns>NHibernate ISession</returns>
        public static NHibernate.ISession OpenSession()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Data Source=LAPTOP-868QL38T\SQLEXPRESS;Initial Catalog=Jewelry;User ID=JUser;Password=qwerty123;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
            });
            cfg.Configure();
            HbmSerializer.Default.Validate = true;
            var stream = HbmSerializer.Default.Serialize(Assembly.GetExecutingAssembly());
            cfg.AddInputStream(stream);
            //cfg.AddAssembly(Assembly.GetExecutingAssembly());
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();

            //Configuration configuration = new Configuration().Configure();
            //var configurePath = @"hibernate.cfg.xml";
            //configuration.Configure(configurePath);
            //configuration.AddAssembly(Assembly.GetExecutingAssembly());
            //ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            //return sessionFactory.OpenSession();


        }
    }
}

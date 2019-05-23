using Jewelry.Database.RepositoryModel;

namespace Jewelry.Business
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Jewelry.Business.LoginService;
    using Jewelry.Business.LoginService.Models;

    public class Service<T> : IService<T>
    {
        private readonly IRepository<T> repository;
        private string connection = @"Data Source=LAPTOP-868QL38T\SQLEXPRESS;Initial Catalog=JewelryStore;User ID=JUser;Password=qwerty123;";
        //private string connection = @"Data Source=EPBYMOGW0027\SQLEXPRESS;Initial Catalog=JewelryStore;User ID=JUser;Password=Qwerty123";
        private SqlConnection connect = null;

        public void OpenConnection()
        {
            connect = new SqlConnection(connection);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }
        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public void Delete(string table, int Id)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand($"Delete{table}", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlparam1 = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = Id
                };
                cmd.Parameters.Add(sqlparam1);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public void Edit(T model)
        {
            repository.InsertOrUpdate(model);
        }

        public T GetById(int Id)
        {
            if (Id < 1)
            {
                return default(T);
            }

            var item = repository.GetById(Id);
            return item;
        }

        public IEnumerable<T> GetList()
        {
            var list = repository.GetList();
            return list;
        }

        public void Insert(T model)
        {
            if (model is User)
            {
                var password = Encryption.GetMd5Hash(model.GetType().GetProperty("Password").GetValue(model).ToString());
                model.GetType().GetProperty("Password").SetValue(model,password);
            }
            repository.InsertOrUpdate(model);
        }

        public IEnumerable<T> ListByProperty(string propertyName, object value)
        {
            return repository.ListByProperty(propertyName, value);
        }
    }
}

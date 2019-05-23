namespace Jewelry.Database.RepositoryModel
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        T GetById(int Id);
        void InsertOrUpdate(T item);
        void Delete(T item);
        IList<T> GetList();

        IEnumerable<T> ListByProperty(string propertyName, object value);
    }
}

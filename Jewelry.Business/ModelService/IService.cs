namespace Jewelry.Business
{
    using System.Collections.Generic;

    public interface IService<T>
    {
        void Insert(T Model);
        IEnumerable<T> GetList();
        T GetById(int Id);
        void Delete(string table, int Id);
        void Edit(T item);
        IEnumerable<T> ListByProperty(string propertyName, object value);
    }
}

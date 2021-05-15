using REST_with_ASP_NET.Model;
using REST_with_ASP_NET.Model.Base;
using System.Collections.Generic;

namespace REST_with_ASP_NET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}

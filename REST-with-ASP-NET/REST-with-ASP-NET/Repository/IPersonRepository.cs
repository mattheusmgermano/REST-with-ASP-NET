using REST_with_ASP_NET.Model;
using REST_with_ASP_NET.Repository.Generic;

namespace REST_with_ASP_NET.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}

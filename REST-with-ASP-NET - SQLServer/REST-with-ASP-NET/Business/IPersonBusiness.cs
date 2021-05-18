using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Hypermedia.Utils;
using REST_with_ASP_NET.Model;
using System.Collections.Generic;

namespace REST_with_ASP_NET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);

        PersonVO Disable(long id);
        void Delete(long id);
    }
}

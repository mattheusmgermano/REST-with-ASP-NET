using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Model;
using System.Collections.Generic;

namespace REST_with_ASP_NET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}

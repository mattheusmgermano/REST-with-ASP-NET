using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Model;
using System.Collections.Generic;

namespace REST_with_ASP_NET.Business
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO book);
        BooksVO FindByID(long id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO book);
        void Delete(long id);
    }
}

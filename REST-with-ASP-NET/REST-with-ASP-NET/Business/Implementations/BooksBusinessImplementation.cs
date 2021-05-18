using REST_with_ASP_NET.Data.Converter;
using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Hypermedia.Utils;
using REST_with_ASP_NET.Model;
using REST_with_ASP_NET.Model.Context;
using REST_with_ASP_NET.Repository;
using REST_with_ASP_NET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_with_ASP_NET.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BooksConverter _converter;
        public BooksBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }
        public PagedSearchVO<BooksVO> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from books p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) query = query + $" and p.title like '%{title}%' ";
            query += $" order by p.title {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from books p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) countQuery = countQuery + $" and p.title like '%{title}%' ";

            var books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BooksVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };  
        }
        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public BooksVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        public BooksVO Create(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        public BooksVO Update(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}

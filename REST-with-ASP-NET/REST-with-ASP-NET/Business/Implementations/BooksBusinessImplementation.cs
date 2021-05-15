using REST_with_ASP_NET.Data.Converter;
using REST_with_ASP_NET.Data.VO;
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

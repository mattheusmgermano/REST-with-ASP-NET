using REST_with_ASP_NET.Model;
using REST_with_ASP_NET.Model.Context;
using REST_with_ASP_NET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_with_ASP_NET.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;
        public BooksBusinessImplementation(IBooksRepository repository)
        {
            _repository = repository;
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll(); ;
        }
        public Book FindByAuthor(string author)
        {
            return _repository.FindByAuthor(author); ;
        }
        public Book FindByID(long id)
        {
            return _repository.FindByID(id); ;
        }
        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }
        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

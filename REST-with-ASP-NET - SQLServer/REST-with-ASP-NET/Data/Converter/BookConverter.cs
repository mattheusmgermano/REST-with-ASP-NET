using REST_with_ASP_NET.Data.Converter.Contract;
using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_with_ASP_NET.Data.Converter
{
    public class BooksConverter : IParser<BooksVO, Book>, IParser<Book, BooksVO>
    {
        public Book Parse(BooksVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }
        public BooksVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BooksVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BooksVO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }


        public List<BooksVO> Parse(List<Book> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

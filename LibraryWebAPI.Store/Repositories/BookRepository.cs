using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Store.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBook()
        {
            return _context.Books.ToList();
        }
        public Book GetBookByBarCode(string barCode)
        {
            return _context.Books.Where(x => x.Barcode == barCode).FirstOrDefault();
        }
        public Book GetBookDetails(int bookId)
        {
            return _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }
        public void EntryBook(Book book)
        {
            _context.Books.Add(book);
        }
        public void UpdateBook( Book book)
        {
            _context.Books.Update(book);
           
        }
        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            _context.Remove(book);
        }



    }
}

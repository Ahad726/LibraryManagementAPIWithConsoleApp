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
        public BookRepository(LibraryContext context )
        {
            _context = context;
        }

        public List<Book> GetAllBook()
        {
            return _context.Books.ToList();
        }

        public Book GetBookDetails(int bookId )
        {
            return _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }

        public void EntryBook(Book book )
        {
            _context.Books.Add(new Book
            {
                BookId = book.BookId,
                Title = book.Title,
                Aurthor = book.Aurthor,
                Edition = book.Edition,
                Barcode = book.Barcode,
                CopyCount = book.CopyCount
            });
            _context.SaveChanges();
        }

        public bool UpdateBook(int bookId, Book book)
        {
            var foundBook =  _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();

            if (foundBook != null )
            {
                foundBook.BookId = book.BookId;
                foundBook.Title = book.Title;
                foundBook.Aurthor = book.Aurthor;
                foundBook.Edition = book.Edition;
                foundBook.CopyCount = book.CopyCount;

                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }                      
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();

            _context.Remove(book);
        }



    }
}

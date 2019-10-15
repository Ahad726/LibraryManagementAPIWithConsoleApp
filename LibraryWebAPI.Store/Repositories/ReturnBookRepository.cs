using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Store.Repositories
{
    public class ReturnBookRepository : IReturnBookRepository
    {
        private LibraryContext _Context;

        public ReturnBookRepository(LibraryContext context)
        {
            _Context = context;
        }

        public Book GetBookByBarCode(string bookBarCode)
        {
            return _Context.Books.Where(b => b.Barcode == bookBarCode).FirstOrDefault();
        }
        public void ReturnBook(int studentId, string bookBarCode)
        {
            var book = GetBookByBarCode(bookBarCode);

            _Context.ReturnBooks.Add(new ReturnBook
            {
                StudentId = studentId,
                BookId = book.BookId,
                BookBarCode = bookBarCode,
                ReturnDate = DateTime.Now
            });
            _Context.SaveChanges();

        }

        public DateTime GetBookReturnDate(int studentId)
        {
            return _Context.ReturnBooks.Where(rb => rb.StudentId == studentId).Select(rb => rb.ReturnDate).FirstOrDefault();
        }

        public void IncreamentBookCountAfterReturn(string BookBarcode)
        {
            var book = GetBookByBarCode(BookBarcode);

            var bookCount = book.CopyCount + 1;

            book.CopyCount = bookCount;
            _Context.SaveChanges();
        }



    }
}

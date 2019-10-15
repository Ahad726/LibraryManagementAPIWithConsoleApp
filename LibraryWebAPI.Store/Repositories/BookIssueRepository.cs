using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Store.Repositories
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private LibraryContext _context;
        public BookIssueRepository(LibraryContext context)
        {
            _context = context;
        }


        //this method used inside this class only 
        //and not to attached inside the interface
        public Book GetBookByBarCode(string bookBarcode)
        {
            return _context.Books.Where(b => b.Barcode == bookBarcode).FirstOrDefault();
        }

        public void IssueBook(int studentId, string bookBarCode)
        {
            var book = GetBookByBarCode(bookBarCode);

            _context.IssueBooks.Add(new IssueBook
            {
                StudentId = studentId,
                BookId = book.BookId,
                BookBarCode = bookBarCode,
                IssueDate = DateTime.Now
            });

        }

        public DateTime GetBookIssueDate(int studentId)
        {
          var student =  _context.IssueBooks.Where(ib => ib.StudentId == studentId).FirstOrDefault();
            return student.IssueDate;
        }

        public void DecreamentBookCountAfterIssue(string BarCode)
        {
            var book = GetBookByBarCode(BarCode);
            var bookCount = book.CopyCount;

            bookCount = bookCount - 1;

            book.CopyCount = bookCount;
            _context.SaveChanges();

        }
    }
}

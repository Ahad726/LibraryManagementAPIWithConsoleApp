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


        public void ReturndBook(ReturnBook returnBook)
        {
            _Context.ReturnBooks.Add(returnBook);

        }

        public DateTime GetBookReturnDate(int studentId)
        {
            return _Context.ReturnBooks.Where(rb => rb.StudentId == studentId).Select(rb => rb.ReturnDate).FirstOrDefault();
        }

        public void IncreamentBookCountAfterReturn(Book book)
        {
            _Context.Books.Update(book);
        }



    }
}

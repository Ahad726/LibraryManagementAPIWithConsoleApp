using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IReturnBookRepository
    {
        void ReturndBook(ReturnBook returnBook);
        DateTime GetBookReturnDate(int studentId);
        void IncreamentBookCountAfterReturn(Book book);
    }
}

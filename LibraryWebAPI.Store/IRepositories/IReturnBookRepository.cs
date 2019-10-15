using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IReturnBookRepository
    {
        void ReturnBook(int studentId, string bookBarCode);
        DateTime GetBookReturnDate(int studentId);
        void IncreamentBookCountAfterReturn(string BookBarcode);
    }
}

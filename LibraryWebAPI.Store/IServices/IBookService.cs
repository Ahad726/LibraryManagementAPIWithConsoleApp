using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IBookService
    {
        void InsertBook(Book book);

        List<Book> ShowAllBook();

        Book GetDetails(int bookId);

        void UpdateBookInfo(Book book);
        void DeleteBook(int bookId);
    }
}

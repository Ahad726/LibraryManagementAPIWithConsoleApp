using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IBookRepository
    {
        void EntryBook(Book book);
        List<Book> GetAllBook();
        Book GetBookByBarCode(string barCode);
        Book GetBookDetails(int bookId);

        void UpdateBook(Book book);

        void DeleteBook(int bookId);

    }
}

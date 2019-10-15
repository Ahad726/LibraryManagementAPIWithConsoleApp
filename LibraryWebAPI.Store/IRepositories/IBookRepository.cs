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

        Book GetBookDetails(int bookId);

        bool UpdateBook(int bookId, Book book);

        void DeleteBook(int bookId);

    }
}

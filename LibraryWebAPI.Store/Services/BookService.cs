using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> ShowAllBook()
        {
            return _bookRepository.GetAllBook();
        }

        public Book GetDetails(int bookId)
        {
            return _bookRepository.GetBookDetails(bookId);
        }

        public void InsertBook(Book book)
        {
            _bookRepository.EntryBook(book);
        }

        public bool UpdateBookInfo(int bookId, Book book)
        {
            return _bookRepository.UpdateBook(bookId, book);
        }

        public void DeleteBook(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
        }
    }
}

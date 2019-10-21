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
        //// Before UnitOfWorkDesignPattern
        #region
        //private IBookRepository _bookRepository;
        //public BookService(IBookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}

        //public List<Book> ShowAllBook()
        //{
        //    return _bookRepository.GetAllBook();
        //}

        //public Book GetDetails(int bookId)
        //{
        //    return _bookRepository.GetBookDetails(bookId);
        //}

        //public void InsertBook(Book book)
        //{
        //    _bookRepository.EntryBook(book);
        //}

        //public bool UpdateBookInfo(int bookId, Book book)
        //{
        //    return _bookRepository.UpdateBook(bookId, book);
        //}

        //public void DeleteBook(int bookId)
        //{
        //    _bookRepository.DeleteBook(bookId);
        //}

        #endregion

        private UnitOfWorkLibraryService _unitOfWorkLibraryService;
        public BookService(UnitOfWorkLibraryService unitOfWorkLibraryService)
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }

        public List<Book> ShowAllBook()
        {
            return _unitOfWorkLibraryService.BookRepository.GetAllBook();
        }

        public Book GetDetails(int bookId)
        {
            return _unitOfWorkLibraryService.BookRepository.GetBookDetails(bookId);
        }

        public void InsertBook(Book book)
        {
            _unitOfWorkLibraryService.BookRepository.EntryBook(book);
            _unitOfWorkLibraryService.save();
        }

        public void UpdateBookInfo(Book book)
        {
            _unitOfWorkLibraryService.BookRepository.UpdateBook(book);
            _unitOfWorkLibraryService.save();
        }

        public void DeleteBook(int bookId)
        {
            _unitOfWorkLibraryService.BookRepository.DeleteBook(bookId);
        }
    }
}

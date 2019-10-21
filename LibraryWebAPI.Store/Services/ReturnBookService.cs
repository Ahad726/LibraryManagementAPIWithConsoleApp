using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class ReturnBookService : IReturnBookService
    {

        //Before UnitOfWork pattern
        #region
        //private IReturnBookRepository _returnBookRepository;

        //public ReturnBookService(IReturnBookRepository returnBookRepository )
        //{
        //    _returnBookRepository = returnBookRepository;
        //}

        //public bool BookReturn(int studentId, string bookBarcode)
        //{
        //    bool isReturned;
        //    try
        //    {
        //        _returnBookRepository.ReturnBook(studentId, bookBarcode);
        //        _returnBookRepository.IncreamentBookCountAfterReturn(bookBarcode);
        //        isReturned = true;

        //    }
        //    catch (Exception)
        //    {

        //        isReturned = false;
        //    }
        //    return isReturned;

        //}
        #endregion

        private UnitOfWorkLibraryService _unitOfWorkLibraryService;
        public ReturnBookService(UnitOfWorkLibraryService unitOfWorkLibraryService)
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }
        public void BookReturn(int studentId, string bookBarcode)
        {

            var book = _unitOfWorkLibraryService.BookRepository.GetBookByBarCode(bookBarcode);
            var student = _unitOfWorkLibraryService.StudentRepository.GetStudentById(studentId);

            if (student != null && book != null)
            {
                var returnBook = new ReturnBook
                {
                    StudentId = studentId,
                    BookId = book.BookId,
                    BookBarCode = bookBarcode,
                    ReturnDate = DateTime.Now
                };

                _unitOfWorkLibraryService.ReturnBookRepository.ReturndBook(returnBook);

                var bookCount = book.CopyCount;
                bookCount += 1;
                book.CopyCount = bookCount;

                _unitOfWorkLibraryService.ReturnBookRepository.IncreamentBookCountAfterReturn(book);
                _unitOfWorkLibraryService.save();
            }
            else
            {
                throw new InvalidOperationException(" Invalid  Operation ");
            }




        }
    }
}

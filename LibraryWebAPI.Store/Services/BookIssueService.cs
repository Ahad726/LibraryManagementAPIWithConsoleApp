using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class BookIssueService : IBookIssueService
    {
        //Before unitOfWork Design Pattern
        #region

        //private IBookIssueRepository _bookIssueRepository;

        //public BookIssueService(IBookIssueRepository bookIssueRepository)
        //{
        //    _bookIssueRepository = bookIssueRepository;
        //}

        //public bool BookIssueToStudent(int studentId, string BookBarcode)
        //{
        //    bool isIssued;
        //    try
        //    {
        //        _bookIssueRepository.IssueBook(studentId, BookBarcode);
        //        _bookIssueRepository.DecreamentBookCountAfterIssue(BookBarcode);
        //        isIssued = true;

        //    }
        //    catch (Exception)
        //    {

        //        isIssued = false;
        //    }
        //    return isIssued;

        //}

        #endregion


        private UnitOfWorkLibraryService _unitOfWorkLibraryService;
        public BookIssueService(UnitOfWorkLibraryService unitOfWorkLibraryService)
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }

        public void BookIssueToStudent(int studentId, string BookBarcode)
        {

            var book = _unitOfWorkLibraryService.BookRepository.GetBookByBarCode(BookBarcode);
            var student = _unitOfWorkLibraryService.StudentRepository.GetStudentById(studentId);
            if (student != null)
            {
                if (book != null)
                {
                    var issuedBook = new IssueBook
                    {
                        StudentId = studentId,
                        BookId = book.BookId,
                        BookBarCode = BookBarcode,
                        IssueDate = DateTime.UtcNow
                    };
                    _unitOfWorkLibraryService.BookIssueRepositor.IssueBook(issuedBook);

                    var bookCount = book.CopyCount;
                    bookCount -= 1;
                    book.CopyCount = bookCount;
                    _unitOfWorkLibraryService.BookIssueRepositor.DecreamentBookCountAfterIssue(book);
                    _unitOfWorkLibraryService.save();

                }
                else
                {
                    throw new InvalidOperationException("This book Is not available");
                }
            }
            else
            {
                throw new InvalidOperationException($"Student Id {studentId} Not a valid Student");
            }

        }

    }
}

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

        public bool BookIssueToStudent(int studentId, string BookBarcode)
        {
            bool isIssued;
            try
            {
                _unitOfWorkLibraryService.BookIssueRepositor.IssueBook(studentId, BookBarcode);
                _unitOfWorkLibraryService.BookIssueRepositor.DecreamentBookCountAfterIssue(BookBarcode);
                isIssued = true;

            }
            catch (Exception)
            {

                isIssued = false;
            }
            return isIssued;

        }

    }
}

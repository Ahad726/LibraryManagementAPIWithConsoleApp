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

        public ReturnBookService(UnitOfWorkLibraryService  unitOfWorkLibraryService )
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }

        public bool BookReturn(int studentId, string bookBarcode)
        {
            bool isReturned;
            try
            {
                _unitOfWorkLibraryService.ReturnBookRepository.ReturnBook(studentId, bookBarcode);
                _unitOfWorkLibraryService.ReturnBookRepository.IncreamentBookCountAfterReturn(bookBarcode);
                isReturned = true;

            }
            catch (Exception)
            {

                isReturned = false;
            }
            return isReturned;

        }


    }
}

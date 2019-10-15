using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class ReturnBookService : IReturnBookService
    {
        private IReturnBookRepository _returnBookRepository;

        public ReturnBookService(IReturnBookRepository returnBookRepository )
        {
            _returnBookRepository = returnBookRepository;
        }

        public bool BookReturn(int studentId, string bookBarcode)
        {
            bool isReturned;
            try
            {
                _returnBookRepository.ReturnBook(studentId, bookBarcode);
                _returnBookRepository.IncreamentBookCountAfterReturn(bookBarcode);
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

using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class BookIssueService : IBookIssueService
    {
        private IBookIssueRepository _bookIssueRepository;

        public BookIssueService(IBookIssueRepository bookIssueRepository)
        {
            _bookIssueRepository = bookIssueRepository;
        }

        public bool BookIssueToStudent(int studentId, string BookBarcode)
        {
            bool isIssued;
            try
            {
                _bookIssueRepository.IssueBook(studentId, BookBarcode);
                _bookIssueRepository.DecreamentBookCountAfterIssue(BookBarcode);
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

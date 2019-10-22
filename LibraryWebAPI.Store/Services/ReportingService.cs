using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
     public class ReportingService : IReportingService
    {
        private UnitOfWorkLibraryService _unitOfWorkLibraryService;

        public ReportingService(UnitOfWorkLibraryService unitOfWorkLibraryService)
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }

        public double CalculateFine(int studentId)
        {
            var bookIssuedate = _unitOfWorkLibraryService.BookIssueRepositor.GetBookIssueDate(studentId);
            var bokReturnDate = _unitOfWorkLibraryService.ReturnBookRepository.GetBookReturnDate(studentId);

            var dayCount = (bokReturnDate - bookIssuedate).Days - 1;

            if (dayCount > 7)
            {
                var delayDays = dayCount - 7;
                double fine = delayDays * 10;

                _unitOfWorkLibraryService.StudentRepository.SetStudentFine(studentId, fine);
                _unitOfWorkLibraryService.save();
                return fine;
            }
            else
            {
                return 0;
            }

        }

        public double checkFine(int studentId)
        {
            return _unitOfWorkLibraryService.StudentRepository.CheckFine(studentId);
        }
        public void ReceiveFine(int studentId, double receivedAmount)
        {
            var studentFine = _unitOfWorkLibraryService.StudentRepository.CheckFine(studentId);
            var remainingFine = studentFine - receivedAmount;
            if (remainingFine > 0)
            {
                _unitOfWorkLibraryService.StudentRepository.SetStudentFine(studentId, remainingFine);
                _unitOfWorkLibraryService.save();
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public  interface IReportingService
    {
        double CalculateFine(int studentId);
        double checkFine(int studentId);
        void ReceiveFine(int studentId, double receivedAmount);
    }
}

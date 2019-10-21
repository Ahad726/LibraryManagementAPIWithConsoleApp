using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IBookIssueService
    {
        void BookIssueToStudent(int studentId, string BookBarcode);


    }
}

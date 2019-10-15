using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IBookIssueService
    {
        bool BookIssueToStudent(int studentId, string BookBarcode);


    }
}

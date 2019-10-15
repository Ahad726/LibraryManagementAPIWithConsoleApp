using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IBookIssueRepository
    {
        void IssueBook(int studentId, string bookBarCode);

        DateTime GetBookIssueDate(int studentId);

        void DecreamentBookCountAfterIssue(string BarCode);
    }
}

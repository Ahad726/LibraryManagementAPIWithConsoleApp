using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IBookIssueRepository
    {
        void IssueBook(IssueBook issueBook);

        DateTime GetBookIssueDate(int studentId);
        void DecreamentBookCountAfterIssue(Book book);
    }
}

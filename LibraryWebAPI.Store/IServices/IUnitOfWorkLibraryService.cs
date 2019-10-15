using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IUnitOfWorkLibraryService
    {
        IBookIssueRepository BookIssueRepositor { get; }
        IReturnBookRepository ReturnBookRepository { get; }
        IBookRepository BookRepository { get; }
        IStudentRepository StudentRepository { get; }

        void save();
    }
}

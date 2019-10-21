using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Store.Repositories
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private LibraryContext _context;
        public BookIssueRepository(LibraryContext context)
        {
            _context = context;
        }


        public void IssueBook(IssueBook issueBook)
        {
            _context.IssueBooks.Add(issueBook);
        }

        public DateTime GetBookIssueDate(int studentId)
        {
          var student =  _context.IssueBooks.Where(ib => ib.StudentId == studentId).FirstOrDefault();
            return student.IssueDate;
        }

        public void DecreamentBookCountAfterIssue(Book book)
        {
            _context.Books.Update(book);

        }
    }
}

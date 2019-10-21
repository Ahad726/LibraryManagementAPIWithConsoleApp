using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagingLibraryController : ControllerBase
    {



        private IBookIssueService _bookIssueService;
        private IReturnBookService _returnBookService;

        public ManagingLibraryController(IBookIssueService bookIssueService, IReturnBookService returnBookService)
        {
            _bookIssueService = bookIssueService;
            _returnBookService = returnBookService;
        }


        // GET api/book
        [HttpGet]
        public ActionResult<IList<Book>> Get()
        {
            return null;
        }



        // POST api/ManagingLibrary/IssueBook
        [HttpPost("/api/ManagingLibrary/IssueBook")]
        public void IssueBook([FromBody] IssueBook issueBook)
        {
            _bookIssueService.BookIssueToStudent(issueBook.StudentId, issueBook.BookBarCode);
        }

        // POST api/ManagingLibrary/ReturnBook
        [HttpPost("/api/ManagingLibrary")]
        public void ReturnBook([FromBody] ReturnBook returnBook)
        {
            _returnBookService.BookReturn(returnBook.StudentId, returnBook.BookBarCode);
        }


    }
}
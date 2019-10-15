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
        public ActionResult IssueBook([FromBody] IssueBook issueBook)
        {
            try
            {
                var isBookIssue = _bookIssueService.BookIssueToStudent(issueBook.StudentId, issueBook.BookBarCode);
                if (isBookIssue)
                {
                    return Ok("Book Successfully Issued");
                }
                else
                {
                    return NotFound("Issue Book Failed");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST api/ManagingLibrary/ReturnBook
        [HttpPost("/api/ManagingLibrary")]
        public ActionResult ReturnBook([FromBody] ReturnBook returnBook)
        {
            try
            {
                var isBookReturn = _returnBookService.BookReturn(returnBook.StudentId, returnBook.BookBarCode);

                if (isBookReturn)
                {
                    return Ok("Book Successfully Returned");
                }
                else
                {
                    return NotFound("Return Book Failed");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}
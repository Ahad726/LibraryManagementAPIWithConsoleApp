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
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/book
        [HttpGet]
        public ActionResult<IList<Book>> Get()
        {
            return _bookService.ShowAllBook();
        }

        // GET api/book/5
        [HttpGet("{bookId}")]
        public Book Get(int bookId)
        {
            return _bookService.GetDetails(bookId);
        }

        // POST api/book
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _bookService.InsertBook(book);
        }

        // PUT api/book/5
        [HttpPut("/api/book/{bookId}")]
        public ActionResult Put(int bookId, [FromBody] Book book)
        {

            var bookUpdate = _bookService.UpdateBookInfo(bookId, book);

            if (bookUpdate)
            {
                return Ok("Book Update Successful");
            }
            else
            {
                return NotFound($"Book with BookId {bookId} Not Found ");
            }
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}

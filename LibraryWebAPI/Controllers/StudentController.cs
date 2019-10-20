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
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/student
        [HttpGet]
        public ActionResult<IList<Student>> Get()
        {
            return null;
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
           
        }

        // POST api/student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _studentService.AddStudent(student);
        }

        // PUT api/student/5
        [HttpPut("{id}")]
        public ActionResult Put(int bookId, [FromBody] Book book)
        {

            return null;
        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
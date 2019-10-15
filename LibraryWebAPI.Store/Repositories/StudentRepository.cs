using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Store.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private LibraryContext _context;
        public StudentRepository(LibraryContext context )
        {
            _context = context;
        }

        public void EnterStudent(Student student )
        {
            _context.Students.Add(new Student
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Fine  = 0
            });
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            _context.Remove(_context.Students.Where(s => s.StudentId == studentId).FirstOrDefault());
        }

        public void SetStudentFine(int studentId, double fine)
        {
            var student =  _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();

            student.Fine = fine;
            _context.SaveChanges();
        }

        public double CheckFine(int studentId)
        {
            return _context.Students.Where(s => s.StudentId == studentId).Select(s => s.Fine).FirstOrDefault();
        }

        public void ReceivedFine(int studentId, double receivedFine)
        {
            var studentFIne = CheckFine(studentId);

            var remainingFine = studentFIne - receivedFine;

            if (remainingFine > 0)
            {
                var student = _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
                student.Fine = remainingFine;
                _context.SaveChanges();
            }
        }
    }
}

using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student )
        {
            _studentRepository.EnterStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _studentRepository.DeleteStudent(studentId);
        }
    }
}

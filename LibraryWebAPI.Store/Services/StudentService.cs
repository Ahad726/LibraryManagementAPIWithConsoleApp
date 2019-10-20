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
        //Before unit of work 
        #region 
        //private IStudentRepository _studentRepository;
        //public StudentService(IStudentRepository studentRepository)
        //{
        //    _studentRepository = studentRepository;
        //}

        //public void AddStudent(Student student )
        //{
        //    _studentRepository.EnterStudent(student);
        //}

        //public void DeleteStudent(int studentId)
        //{
        //    _studentRepository.DeleteStudent(studentId);
        //}
        #endregion

        private UnitOfWorkLibraryService _unitOfWorkLibraryService;
        public StudentService(UnitOfWorkLibraryService unitOfWorkLibraryService)
        {
            _unitOfWorkLibraryService = unitOfWorkLibraryService;
        }

        public void AddStudent(Student student)
        {
            _unitOfWorkLibraryService.StudentRepository.EnterStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _unitOfWorkLibraryService.StudentRepository.DeleteStudent(studentId);
        }


    }
}

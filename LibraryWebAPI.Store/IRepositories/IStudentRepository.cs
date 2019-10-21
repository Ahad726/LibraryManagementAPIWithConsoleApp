using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IRepositories
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);
        void EnterStudent(Student student);
        void DeleteStudent(int studentId);
        void SetStudentFine(int studentId, double fine);
        double CheckFine(int studentId);
        void ReceivedFine(int studentId, double receivedFine);
    }
}

using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
    }
}

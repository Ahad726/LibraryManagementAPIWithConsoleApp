using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class EntryStudent
    {
        public void studentEntry()
        {
            Student student = new Student();

            Console.WriteLine("Entry Student Information center");
            Console.WriteLine("===============================");
            Console.Write("Please enter student Id: ");
            student.StudentId = Convert.ToInt32((Console.ReadLine()));

            Console.Write("Please enter student Name: ");
            student.Name = Console.ReadLine();
            
            Console.WriteLine("===============================");

            PostRequest postRequest = new PostRequest();
            postRequest.Insert(student, "Student");
        }
    }
}

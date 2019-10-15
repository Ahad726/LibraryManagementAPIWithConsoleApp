using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class ReceiveFine
    {
        public void FineReceive()
        {
            Student student = new Student();
            Console.WriteLine("Receive the Fine");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Student Id : ");
            student.StudentId = int.Parse(Console.ReadLine());


            Console.Write("Please Enter Fine amount You want to pay : ");
            student.Fine = double.Parse(Console.ReadLine());

            PostRequest postRequest = new PostRequest();
            postRequest.Insert(student, "Reporting");

        }
    }
}

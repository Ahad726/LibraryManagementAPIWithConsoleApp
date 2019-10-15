using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class CheckFine
    {
        public void CheckStudentFine()
        {
            

            Console.WriteLine("Check Fine");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Student Id : ");
            var studentId = int.Parse(Console.ReadLine());


            GetFineRequest getFineRequest = new GetFineRequest();
           ;

            Console.WriteLine($"Student Id : {studentId} Fine Amount:  " + getFineRequest.GetFine(studentId));
        }
    }
}

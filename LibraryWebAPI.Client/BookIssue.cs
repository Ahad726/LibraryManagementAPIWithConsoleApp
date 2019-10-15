using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class BookIssue
    {
        public void IssueBookToStudent()
        {
            IssueBook issueBook = new IssueBook();

            Console.WriteLine("Issue a book to student");
            Console.WriteLine("===============================");
            Console.Write("Please Enter Student Id : ");
            issueBook.StudentId = Convert.ToInt32((Console.ReadLine()));

            Console.Write("Please Enter Book Barcode : ");
            issueBook.BookBarCode = Console.ReadLine();
            Console.WriteLine("===============================");

            PostRequest postRequest = new PostRequest();
            postRequest.Insert(issueBook, "ManagingLibrary/IssueBook");
        }
    }
}

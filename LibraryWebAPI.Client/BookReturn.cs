using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class BookReturn
    {
        public void ReturnBookInfo()
        {
            ReturnBook returnBook = new ReturnBook();

            Console.WriteLine("Return a book ");
            Console.WriteLine("===============================");
            Console.Write("Please Enter Student Id : ");
            returnBook.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Please Enter Book Barcode : ");
            returnBook.BookBarCode = Console.ReadLine();


            PostRequest postRequest = new PostRequest();
            postRequest.Insert(returnBook, "ManagingLibrary");
        }
    }
}

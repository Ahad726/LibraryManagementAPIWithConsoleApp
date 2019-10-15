using LibraryWebAPI.Client.WebRequestHandle;
using LibraryWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Client
{
    public class BookEntry
    {
        public void EntryBook()
        {
            Book book = new Book();

            Console.WriteLine("Entry Book Section: ");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Book Id: ");
            book.BookId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter Book Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Please enter Book Author: ");
            book.Aurthor = Console.ReadLine();

            Console.Write("Please enter Book Edition: ");
            book.Edition = Console.ReadLine();

            Console.Write("Please enter Barcode of the book: ");
            book.Barcode = Console.ReadLine();

            Console.Write("Please enter Copy Count of the book: ");
            book.CopyCount = int.Parse(Console.ReadLine());
            Console.WriteLine("===============================");

            PostRequest postRequest = new PostRequest();
            postRequest.Insert(book, "Book");
        }
    }
}

using LibraryWebAPI.Client.WebRequestHandle;
using System;

namespace LibraryWebAPI.Client
{
    class Program
    {
        static void Main(string[] args)
        {




        star:
            Console.Clear();
            Console.WriteLine("\t=================================================================================");
            Console.WriteLine("\t\t\t\tWelcome to library system.");

            Console.WriteLine("\t\t\t\tTo entry student information enter: 1");
            Console.WriteLine("\t\t\t\tTo entry book information enter: 2");
            Console.WriteLine("\t\t\t\tTo issue a book, enter: 3");
            Console.WriteLine("\t\t\t\tTo return a book enter: 4");
            Console.WriteLine("\t\t\t\tTo check fine, enter: 5 ");
            Console.WriteLine("\t\t\t\tTo receive fine, enter: 6");
            Console.WriteLine("\t=================================================================================");

            try
            {
                Console.Write("\n\n\nPlease enter your choice: ");
                int ch = int.Parse(Console.ReadLine());


                Console.WriteLine("=================================");


                switch (ch)
                {
                    case 1:
                        EntryStudent entryStudent = new EntryStudent();
                        entryStudent.studentEntry();
                        break;

                    case 2:

                        BookEntry bookEntry = new BookEntry();
                        bookEntry.EntryBook();
                        break;

                    case 3:
                        BookIssue bookIssue = new BookIssue();
                        bookIssue.IssueBookToStudent();
                        break;

                    case 4:
                        BookReturn bookReturn = new BookReturn();
                        bookReturn.ReturnBookInfo();
                        break;

                    case 5:
                        CheckFine checkFine = new CheckFine();
                        checkFine.CheckStudentFine();
                        break;

                    case 6:
                        ReceiveFine receiveFine = new ReceiveFine();
                        receiveFine.FineReceive();
                        break;


                    default:
                        Console.WriteLine("Invalid Key Given.Please Try Again");
                        break;

                }




            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Console.Beep(400, 1500);

                goto star;

            }






        }
    }
}

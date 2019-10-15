using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Core
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fine { get; set; }
        public IList<IssueBook> IssueBooks { get; set; }
        public IList<ReturnBook> ReturnBooks { get; set; }
    }
}

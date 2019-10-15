using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Core
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Aurthor { get; set; }
        public string Edition { get; set; }
        public string Barcode { get; set; }
        public int CopyCount { get; set; }
    }
}

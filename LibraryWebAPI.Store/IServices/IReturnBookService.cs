using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IReturnBookService
    {
        bool BookReturn(int studentId, string bookBarcode);
    }
}

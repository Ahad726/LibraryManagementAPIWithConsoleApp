using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.IServices
{
    public interface IReturnBookService
    {
        void BookReturn(int studentId, string bookBarcode);
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LibraryWebAPI.Client.WebRequestHandle
{
    public class GetFineRequest
    {
        public double GetFine(int Id)
        {
            var webRequest = new WebClient();
            webRequest.BaseAddress = "http://localhost:3614";
            var result = webRequest.DownloadString("/api/Reporting/" + Id);
            return double.Parse(result);
        }
    }
}
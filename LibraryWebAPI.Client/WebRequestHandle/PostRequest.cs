using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LibraryWebAPI.Client.WebRequestHandle
{
    public class PostRequest
    {


        public void Insert(object addObject, string ControllerName)
        {

            string url = "http://localhost:3614/api/" + ControllerName;
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            var requestContent = JsonConvert.SerializeObject(addObject);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();


                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                            Console.WriteLine(result);
                        }
                    }
                }




            }
        }


    }
}

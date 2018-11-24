using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;


namespace Models
{
    //Developed By Mustafizur Rahman

    public class ApiResult
    {
        public string Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }


    public class SendService
    {
        public ApiResult Send(string url, string json)
        {
            try
            {



                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                string result = string.Empty;
                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //{
                //    streamWriter.Write(json);
                //    streamWriter.Flush();
                //    streamWriter.Close();
                //}

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                   
                  

                    //new CDA().ExecuteNonQuery("EXEC [BDApps].[dbo].[Sptbl_ApiResponseInsert] '" + result + "','" + (int)httpResponse.StatusCode + "','" + json + "'", "API");
                }
            


                return new ApiResult
                {
                    Result = result,
                    StatusCode = httpResponse.StatusCode
                };

            }
            catch (Exception e)
            {
                return new ApiResult
                {
                    Result = e.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
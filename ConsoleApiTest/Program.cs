using DB.Date.DbLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApiTest
{
    class Program
    {
        internal class DateStore
        {
            public static List<DateLine> dateLines()
            {
                return new List<DateLine>
                {
                    new DateLine
                    {
                        FirstDate=new DateTime(2018,01,01),
                        LastDate=new DateTime(2018,01,03),
                    },
                    new DateLine
                    {
                        FirstDate=new DateTime(2018,01,01),
                        LastDate=new DateTime(2018,01,31),
                    },
                    new DateLine
                    {
                        FirstDate=new DateTime(2018,01,03 ),
                        LastDate=new DateTime(2018,01,05),
                    }
                };
            }
        } 
        
        static void Main(string[] args)
        {
            
            
            IEnumerable <DateLine> collection = DateStore.dateLines();
            foreach (var item in collection)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50608/api/date");
                var data = JsonConvert.SerializeObject(item);
                request.UserAgent = "MyApplication";
                request.Method = "Post";
                request.ContentType = "application/json";
                var b_data = Encoding.ASCII.GetBytes(data);
                using(Stream stram = request.GetRequestStream())
                {
                    stram.Write(b_data, 0, b_data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
            }
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://localhost:50608/api/AddReturn");
            DateLine dateLine = new DateLine
            {
                FirstDate = new DateTime(2018,01,04),
                LastDate = new DateTime(2018,02,03)
            };
            var data2 = JsonConvert.SerializeObject(dateLine);
            request2.UserAgent = "MyApplication";
            request2.Method = "Post";
            request2.ContentType = "application/json";
            var b_data2 = Encoding.ASCII.GetBytes(data2);
            using (Stream stram = request2.GetRequestStream())
            {
                stram.Write(b_data2, 0, b_data2.Length);
            }

            string response_str = string.Empty;
            using(WebResponse response = request2.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    response_str = stream.ReadToEnd();
                }
            }

            var response_data = JsonConvert.DeserializeObject<IEnumerable<DateLine>>(response_str);

            



        }
    }
}

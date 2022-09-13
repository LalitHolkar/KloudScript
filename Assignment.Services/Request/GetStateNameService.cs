using Assignment.Services.Response;
using Assignmet.Entity.Model.Model;
using Newtonsoft.Json;
//using RestSharp;
using System;
using System.Net.Http;

namespace Assignment.Services.Request
{
    public class GetStateNameService
    {
        public static HttpResponse GetState(string pincode)
        {
            HttpResponse result = new HttpResponse();

            try
            {

                string apiUrl = "http://www.postalpincode.in/api/pincode/" + pincode;
                HttpClient client = new HttpClient();
                var response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var res = JsonConvert.DeserializeObject<PostOfficeDetails>(response.Content.ReadAsStringAsync().Result);
                    result.Data = res;
                }
                else
                {
                    result.Data = null;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using Assignment.Data;
using Assignment.Services.Request;
using Assignment.Services.Response;
using Assignmet.Entity.Model.Model;
using Assignmet.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignmet.Repository.Repository
{
    public class GenerateUrlS : IGenerateUrlS
    {
        private readonly AssignmentContext dbcontext;
        HttpResponse response;
        public GenerateUrlS(AssignmentContext _dbcontext)
        {
            this.dbcontext = _dbcontext;

        }
        /// <summary>
        /// Create Short Url
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public HttpResponse CreateUrl(string Url)
        {
            response = new HttpResponse();
            string result = "https://shot.url/" + GenrateRandomURL.GetURL();
            var shortURL = new GenerateURL()
            {
                FullUrl = Url,
                shortUrl = result
            };
            try
            {
                dbcontext.AddAsync(shortURL);
                dbcontext.SaveChangesAsync();
                response.StatusCode = 200;
                response.Message = "Success";
                response.Data = shortURL;
                response.Status = true;
            }
            catch (Exception)
            {
                response.StatusCode = 123;
                response.Message = "Failed";
                response.Data = shortURL;
                response.Status = false;
                throw;
            }
            return response;

        }
        /// <summary>
        /// Het Full Url By SHort Url
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public HttpResponse GetUrl(string Url)
        {
            response = new HttpResponse();
            try
            {
                response.Data = dbcontext.GenerateURL.Where(x => x.shortUrl == Url).Select(x => x.FullUrl).FirstOrDefault();
                response.StatusCode = 200;
                response.Message = "Success";

                response.Status = true;
            }
            catch (Exception)
            {
                response.StatusCode = 204;
                response.Message = "Failed";
                response.Data = null;
                response.Status = false;
                throw;
            }
            return response;
        }

        /// <summary>
        /// Get All the Records
        /// </summary>
        /// <returns></returns>

        public HttpResponse GetAllUrl()
        {
            response = new HttpResponse();
            try
            {
                response.Data = dbcontext.GenerateURL.ToList();
                response.StatusCode = 200;
                response.Message = "Success";
                response.Status = true;
            }
            catch (Exception)
            {
                response.StatusCode = 204;
                response.Message = "Failed";
                response.Data = null;
                response.Status = false;
                throw;
            }
            return response;
        }

        /// <summary>
        /// Get All Information Using Pincode
        /// </summary>
        /// <param name="PinCode"></param>
        /// <returns></returns>
        public HttpResponse GetStateName(string PinCode) {
            response = new HttpResponse();
            response.Data= GetStateNameService.GetState(PinCode);
            if (response.Data != null)
            {
                response.StatusCode = 200;
                response.Message = "Success";
                response.Status = true;
            }
            else {
                response.StatusCode = 204;
                response.Message = "Failed";
                response.Data = null;
                response.Status = false;
            }
            return response;
        }
    }
}

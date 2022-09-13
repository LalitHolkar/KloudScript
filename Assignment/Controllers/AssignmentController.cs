using Assignment.Data;
using Assignment.Services.Response;
using Assignmet.Entity.Model.Model;
using Assignmet.Repository.IRepository;
//using Assignment.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IGenerateUrlS _IGenerateUrlS;
        HttpResponse response;
        public AssignmentController(IGenerateUrlS GenerateUrlS)
        {
            this._IGenerateUrlS = GenerateUrlS;
        }

        [Route("GenerateUrl")]
        [HttpPost]
        public HttpResponse CreateShortUrl(string Url)
        {
            response = new HttpResponse();
            if (!string.IsNullOrEmpty(Url))
            {
                response = _IGenerateUrlS.CreateUrl(Url);
            }
            else
            {
                response.Status = false;
                response.Message = "Add Url to Convert";
                response.Data = null;
                response.StatusCode =204;
            }
            return response;
        }

        [Route("GetByShortUrl")]
        [HttpGet]
        public HttpResponse Get(string Url)
        {
            response = new HttpResponse();
            if (!string.IsNullOrEmpty(Url))
            {
                response = _IGenerateUrlS.GetUrl(Url); 
            }
            else
            {
                response.Status = false;
                response.Message = "Add Url to Convert";
                response.Data = null;
                response.StatusCode =204;
            }
            return response;
        }

        [Route("GetAll")]
        [HttpGet]
        public HttpResponse GetAll()
        {
            response = new HttpResponse();
            response = _IGenerateUrlS.GetAllUrl();
            return response;
        }

        [Route("GetState")]
        [HttpGet]
        public HttpResponse GetStateName(string Zipcode)
        {
            response = new HttpResponse();
            if (!string.IsNullOrEmpty(Zipcode))
            {
                response = _IGenerateUrlS.GetStateName(Zipcode); 
            }
            else
            {
                response.Status = false;
                response.Message = "Add Zipcode to fetch details";
                response.Data = null;
                response.StatusCode = 204;
            }
            return response;
        }

    }
}

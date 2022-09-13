using Assignment.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmet.Repository.IRepository
{
    public interface IGenerateUrlS
    {
        HttpResponse CreateUrl(string Url);
        HttpResponse GetUrl(string Url);
        HttpResponse GetAllUrl();
        HttpResponse GetStateName(string PinCode);
    }
}

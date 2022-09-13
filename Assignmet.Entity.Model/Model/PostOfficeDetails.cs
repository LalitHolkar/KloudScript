using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmet.Entity.Model.Model
{
    public class PostOfficeDetails
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public List<PostOffice> PostOffice { get; set; }
    }
}

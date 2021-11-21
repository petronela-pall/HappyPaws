using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    
    public class PagingInfo
    {
        
        public int TotalCustomers { get; set; }
        public int CustomersPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNoPages => (int)Math.Ceiling((decimal)TotalCustomers / CustomersPerPage);
        public string UrlParam { get; set; }
    }
}

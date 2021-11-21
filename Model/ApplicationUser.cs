using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

      
       public int Telephonenumber { get; set; }
       public string PhoneNumber { get; set; }

       
    }
}

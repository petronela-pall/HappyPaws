using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Data;
using HappyPaws.Model;

namespace HappyPaws.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly HappyPaws.Data.ApplicationDbContext _context;

        public IndexModel(HappyPaws.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; }

        public async Task OnGetAsync()
        {
            Doctor = await _context.Doctor.ToListAsync();
        }
    }
}

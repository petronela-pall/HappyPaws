using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyPaws.Data;
using HappyPaws.Model;
using HappyPaws.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Pages.MedicalServices
{
   // [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<MedicalService> MedicalService { get; set; }
            
            
            
        public async Task<IActionResult> OnGet()
        {
            MedicalService = await _db.MedicalService.ToListAsync();
            return Page();
        }
    }
}

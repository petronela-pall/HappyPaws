using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Data;
using HappyPaws.Model;
using Microsoft.AspNetCore.Authorization;
using HappyPaws.Utility;

namespace HappyPaws.Pages.MedicalServices
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public MedicalService MedicalService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalService = await _db.MedicalService.FirstOrDefaultAsync(m => m.ID == id);

            if (MedicalService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

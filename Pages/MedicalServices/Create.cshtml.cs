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

namespace HappyPaws.Pages.MedicalServices
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public MedicalService MedicalService { get; set;  }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(MedicalService MedicalService)
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.MedicalService.Add(MedicalService);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
   
    }
}

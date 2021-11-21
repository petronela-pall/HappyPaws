using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HappyPaws.Data;
using HappyPaws.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HappyPaws.Pages.Pets
{
    [Authorize]
    public class CreateModel : PageModel
    {
        
        public readonly ApplicationDbContext _db;

        [BindProperty]
        public Pet Pet { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(string userId=null)
        {
            Pet = new Pet();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Pet.UserId = userId;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Pet Pet)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Pet.Add(Pet);
            await _db.SaveChangesAsync();

            StatusMessage = "Pet added succesfully!";

            return RedirectToPage("Index", new {userId=Pet.UserId });
        }

    }
}

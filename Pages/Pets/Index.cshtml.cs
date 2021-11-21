using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HappyPaws.Data;
using HappyPaws.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Utility;
using Microsoft.AspNetCore.Authorization;

namespace HappyPaws.Pages.Pets
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PetClientViewModel PetClientVM { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
             _db= db;
        }
        public async Task<IActionResult> OnGet(string userId=null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            PetClientVM = new PetClientViewModel()
            {
                Pets = await _db.Pet.Where(p => p.UserId == userId).ToListAsync(),
                UserObj = await _db.ApplicationUSer.FirstOrDefaultAsync(u => u.Id == userId)
            };
            return Page();
        }
    }
}

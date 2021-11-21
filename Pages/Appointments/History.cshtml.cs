using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyPaws.Data;
using HappyPaws.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Pages.Appointments
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //dependency injection:
        public HistoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<MedicalServiceHeader>MedicalServiceHeader { get; set; }
        public string UserId { get; set; }
        public async Task OnGet(int petId)
        {
            //i want to retrieve all the headers ; use include pet and user because we need to display
            //both pet and owner details
            MedicalServiceHeader = await _db.MedicalServiceHeader.Include(s => s.Pet).Include(c => c.Pet.ApplicationUser)
                .Where(c => c.PetId == petId).ToListAsync();
            //retrieving the user id
            UserId = _db.Pet.Where(u => u.Id == petId).ToList().FirstOrDefault().UserId;
        }
    }
}

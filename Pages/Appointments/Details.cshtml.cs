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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public MedicalServiceHeader MedicalServiceHeader { get; set; }
        public List<AppointmentDetails> AppointmentDetails { get; set; }

        public void OnGet(int appointmentId)
        {
            //get the appt header
            MedicalServiceHeader = _db.MedicalServiceHeader
                .Include(s => s.Pet)
                .Include(s => s.Pet.ApplicationUser)
                .FirstOrDefault(s => s.Id == appointmentId);
            //retrieve appt details
            AppointmentDetails = _db.AppointmentDetails.Where(s => s.MedicalServiceHeaderId == appointmentId).ToList();
        }
    }
}

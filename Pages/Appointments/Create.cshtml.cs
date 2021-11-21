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

namespace HappyPaws.Pages.Appointments
{
    [Authorize(Roles =SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public PetAppointmentViewModel PetAppointmentVM { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int petId)
        {
            PetAppointmentVM = new PetAppointmentViewModel
            {
                Pet = await _db.Pet.Include(c => c.ApplicationUser).FirstOrDefaultAsync(c => c.Id == petId),
                MedicalServiceHeader = new Model.MedicalServiceHeader()
            };
            List<String> lstMedicalServiceInShoppingCart = _db.MedicalServiceShoppingCart
                                                                    .Include(c => c.MedicalService)
                                                                    .Where(c => c.PetId == petId)
                                                                    .Select(c => c.MedicalService.Name)
                                                                    .ToList();
            //o data ce adaugi un serviciu, dispare din lista
            IQueryable<MedicalService> lstRecord = from s in _db.MedicalService
                                                   where (!lstMedicalServiceInShoppingCart.Contains(s.Name))
                                                   select s;

            PetAppointmentVM.MedicalServiceList = lstRecord.ToList();
            PetAppointmentVM.MedicalServiceShoppingCart = _db.MedicalServiceShoppingCart.Include(c => c.MedicalService).Where(c => c.PetId == petId).ToList();
            PetAppointmentVM.MedicalServiceHeader.TotalPrice = 0;

            foreach(var item in PetAppointmentVM.MedicalServiceShoppingCart)
            {
                PetAppointmentVM.MedicalServiceHeader.TotalPrice += item.MedicalService.Price;
            }

            return Page();
        }

        public async Task<IActionResult>OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                PetAppointmentVM.MedicalServiceHeader.AppointmentDate = DateTime.Now;
                PetAppointmentVM.MedicalServiceShoppingCart = _db.MedicalServiceShoppingCart.Include(c => c.MedicalService).ToList();
                foreach(var item in PetAppointmentVM.MedicalServiceShoppingCart)
                {
                    PetAppointmentVM.MedicalServiceHeader.TotalPrice += item.MedicalService.Price;
                }
                PetAppointmentVM.MedicalServiceHeader.PetId = PetAppointmentVM.Pet.Id;
                _db.MedicalServiceHeader.Add(PetAppointmentVM.MedicalServiceHeader);
                await _db.SaveChangesAsync();

                foreach(var detail in PetAppointmentVM.MedicalServiceShoppingCart)
                {
                    AppointmentDetails appointmentDetails = new AppointmentDetails
                    {
                        MedicalServiceHeaderId = PetAppointmentVM.MedicalServiceHeader.Id,
                        MedicalServiceName = detail.MedicalService.Name,
                        MedicalServicePrice = detail.MedicalService.Price,
                        MedicalServiceID = detail.MedicalServiceID,

                    };
                    _db.AppointmentDetails.Add(appointmentDetails);
                    
                }

                //to remove the items from shopping cart = > history
                _db.MedicalServiceShoppingCart.RemoveRange(PetAppointmentVM.MedicalServiceShoppingCart);
                await _db.SaveChangesAsync();

                return RedirectToPage("../Pets/Index", new { userId = PetAppointmentVM.Pet.UserId });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCart()
        {
            //cream obiect shopping cart si il salvam to db
            MedicalServiceShoppingCart objMedicalServiceCart = new MedicalServiceShoppingCart()
            {
                PetId = PetAppointmentVM.Pet.Id,
                MedicalServiceID = PetAppointmentVM.AppointmentDetails.MedicalServiceID
            };
            _db.MedicalServiceShoppingCart.Add(objMedicalServiceCart);
           
            await _db.SaveChangesAsync();
            //redirect to same page, passing PetId in the URL
            return RedirectToPage("Create", new { petId = PetAppointmentVM.Pet.Id });
        }
        public async Task<IActionResult> OnPostRemoveFromCart(int medicalServiceID)
        {
            //cream obiect shopping cart si il salvam to db
            MedicalServiceShoppingCart objMedicalServiceCart = _db.MedicalServiceShoppingCart
                .FirstOrDefault(u => u.PetId == PetAppointmentVM.Pet.Id && u.MedicalServiceID == medicalServiceID);

            _db.MedicalServiceShoppingCart.Remove(objMedicalServiceCart);

            await _db.SaveChangesAsync();
            //redirect to same page, passing PetId in the URL
            return RedirectToPage("Create", new { petId = PetAppointmentVM.Pet.Id });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Data;
using HappyPaws.Model;
using HappyPaws.Model.ViewModel;
using HappyPaws.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public CustomersListViewModel UsersListVM { get; set; }
        public async Task<IActionResult> OnGet(int productPage =1, String searchEmail=null, String searchName = null, String searchPhone = null)
        {
            UsersListVM = new CustomersListViewModel()
            {
                ApplicationUserList = await _db.ApplicationUSer.ToListAsync()
            };
            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
           
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }


            if (searchEmail != null)
            {
                UsersListVM.ApplicationUserList = await _db.ApplicationUSer.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
             }
            else
            {
                if(searchName!=null){
                    UsersListVM.ApplicationUserList = await _db.ApplicationUSer.Where(u => u.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchPhone != null)
                    {
                       // UsersListVM.ApplicationUserList = await _db.ApplicationUSer.Where(u => u.PhoneNumber.ToLower.Contains(searchPhone.ToLower())).ToListAsync();
                    }
                }
            }

            var count = UsersListVM.ApplicationUserList.Count;
            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                CustomersPerPage = SD.Pagination,
                TotalCustomers = count,
                UrlParam = param.ToString()

            };
            UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.OrderBy(p => p.Email)
                .Skip((productPage-1) *SD.Pagination)
                .Take(SD.Pagination).ToList();
         
            return Page();
        }
    }
}

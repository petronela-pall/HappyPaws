using HappyPaws.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPaws.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MedicalService> MedicalService { get; set; }
        public DbSet<ApplicationUser> ApplicationUSer { get; set; }
        public object ApplicationUser { get; internal set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<MedicalServiceShoppingCart> MedicalServiceShoppingCart { get; set; }
        public DbSet<MedicalServiceHeader> MedicalServiceHeader { get; set; }
        public DbSet<AppointmentDetails> AppointmentDetails { get; set; }

    }
}

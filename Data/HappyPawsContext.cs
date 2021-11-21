using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Model;

namespace HappyPaws.Data
{
    public class HappyPawsContext : DbContext
    {
        public HappyPawsContext (DbContextOptions<HappyPawsContext> options)
            : base(options)
        {
        }

        public DbSet<HappyPaws.Model.MedicalService> MedicalService { get; set; }
    }
}

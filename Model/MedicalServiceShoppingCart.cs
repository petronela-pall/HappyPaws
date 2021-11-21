using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class MedicalServiceShoppingCart

    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int MedicalServiceID { get; set; }

        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        [ForeignKey("MedicalServiceID")]
        public virtual MedicalService MedicalService { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class MedicalServiceHeader
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        public string Details { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime AppointmentDate { get; set; }

        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class AppointmentDetails
    {
        public int Id { get; set; }
        public int MedicalServiceHeaderId { get; set; }
        [ForeignKey("MedicalServiceHeaderId")]
        public virtual MedicalServiceHeader MedicalServiceHeader { get; set; }

        [Display(Name="Medical Service")]
        public int MedicalServiceID{ get; set; }
        [ForeignKey("MedicalServiceID")]
        public virtual MedicalService MedicalService { get; set; }

        public double MedicalServicePrice { get; set; }

        public string MedicalServiceName { get; set; }
    }

}
   


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyPaws.Model
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Specialty")]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Chip Id")]
        public int ChipId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Breed { get; set; }

        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model
{
    public class DOBDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            if (!parsed)
                return new ValidationResult("Invalid Date");
            else
            {
               
                var min = DateTime.Now; 
                var max = DateTime.Now.AddYears(-50); 
                var msg = string.Format("Please enter a value between {0:MM/dd/yyyy} and {1:MM/dd/yyyy}", max, min);
                try
                {
                    if (date > min || date < max)
                        return new ValidationResult(msg);
                    else
                        return ValidationResult.Success;
                }
                catch (Exception e)
                {
                    return new ValidationResult(e.Message);
                }
            }

        }
    }
   
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
       
        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString ="{0:mm/dd/yyy}")]
        [Display(Name = "Date of Birth")]
        [DOBDateValidation]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
   
}

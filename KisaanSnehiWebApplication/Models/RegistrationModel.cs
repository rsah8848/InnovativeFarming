using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public class RegistrationModel 
    {


        public int RegId { get; set; }

        public int UserTypeId { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "limit exceeded")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "limit exceeded")]
        [Display(Name = "Email")]
        public string EmailId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{10})\)?$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public long PhoneNo { get; set; }
        [StringLength(100, ErrorMessage = "limit exceeded")]
        public string Address { get; set; }

        public int LocationId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$",
         ErrorMessage = "Password must meet requirements")]
        /* [StringLength(12, ErrorMessage = "Must be between 8 and 12 characters", MinimumLength = 8)]*/
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Security Question")]
        [Required]
        public string SecurityQue { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "limit exceeded")]
        public string Answer { get; set; }

        [DisplayName("Upload File")]
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        public bool IsDeleted { get; set; }

        
    }
}

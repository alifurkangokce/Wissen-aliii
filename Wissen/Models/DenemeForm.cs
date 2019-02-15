using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wissen.Models
{
    public class DenemeForm
    {
        [Required(ErrorMessage ="{0} alanı gereklidir")]
        [MaxLength]
        [Display(Name ="Ad")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

    }
}
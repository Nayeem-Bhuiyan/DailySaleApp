using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Auth.Models
{
    public class LogInViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} at most {1} characters long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

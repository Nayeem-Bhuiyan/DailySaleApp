
using Microsoft.AspNetCore.Http;
using NayeemSaleApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Auth.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }//User Name
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public int? userTypeId { get; set; } 
        public IFormFile ImgeUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }

        public IEnumerable<ApplicationRoleViewModel> userRoles { get; set; }
        public IEnumerable<AspNetUsersViewModel> aspNetUsers { get; set; }
    }
}

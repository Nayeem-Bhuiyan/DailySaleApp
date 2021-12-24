using System;
using System.Collections.Generic;
using System.Text;

namespace NayeemSaleApp.Areas.Auth.Models
{
    public class AspNetUsersViewModel
    {
        public string aspnetId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int? UserTypeId { get; set; }
        public int? isActive { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string userTypeName { get; set; }
        public DateTime? joiningDate { get; set; }
        public DateTime? createdAt { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
        public int? status { get; set; }
        public int? photoId { get; set; }
        public string roleId { get; set; }
        public string roleName{ get; set; }
        public string imageUrl { get; set; }
    }
}

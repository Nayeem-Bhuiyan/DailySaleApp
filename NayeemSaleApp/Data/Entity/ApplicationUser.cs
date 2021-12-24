
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DailyExpenseTracker.Data.Entity
{
    public class ApplicationUser: IdentityUser
    {
        
        public int? isActive { get; set; }
        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string createdBy { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string updatedBy { get; set; }
    }
}

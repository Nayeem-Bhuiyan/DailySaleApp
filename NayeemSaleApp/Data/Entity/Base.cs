using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NayeemSaleApp.Data.Entity
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DefaultValue(0)]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(250)]
        public string createdBy { get; set; }
        [MaxLength(250)]
        public string updatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        public String DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public String Gender { get; set; }

        [Required]
        [MaxLength(10)]
        public String PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public String Email { get; set; }
    }
}
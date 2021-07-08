using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Session
    {
        public int SessionID { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
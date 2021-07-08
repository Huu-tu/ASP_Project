using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Term
    {
        [Key]
        public int TermID { get; set; }

        [Required]
        [MaxLength(50)]
        public String TermName { get; set; }

        [Required]
        public String DayStart { get; set; }

        [Required]
        public String DayFinish { get; set; }

        //nevigation
        public List<Course> Courses { get; set; }

        public static implicit operator Term(string v)
        {
            throw new NotImplementedException();
        }
    }
}
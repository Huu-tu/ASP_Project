using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class TraineeAsign
    {
        public int TraineeAsignID { get; set; }

        [Required]
        public int TraineeID { get; set; }
        
        [Required]
        public int CourseID { get; set; }

        public virtual Trainee Trainee { get; set; }
        public virtual Course Course { get; set; }

    }
}
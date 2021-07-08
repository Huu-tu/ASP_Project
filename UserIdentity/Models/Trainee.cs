using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Trainee
    {
        public int TraineeID { get; set; }

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

        [Required]
        public int TOEIC { get; set; }

        [Required]
        [MaxLength(50)]
        public String City { get; set; }

        //nevigation
        public List<TrainerAsign> TrainerAsigns { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(50)]
        public String CourseName { get; set; }

        [Required]

        public String CourseDescription { get; set; }


        
        [Required]
        public int TrainerID { get; set; }

        [Required]
        public int TopicID { get; set; }

        [Required]
        public int TermID { get; set; }

        public Trainer Trainer { get; set; }

        public Topic Topic { get; set; }

        public Term Term { get; set; }

        public List<TraineeAsign> TraineeAsigns { get; set; }

        public List<Session> Sessions { get; set; }
    }
    

}

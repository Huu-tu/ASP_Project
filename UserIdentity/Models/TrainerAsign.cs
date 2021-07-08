using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Models
{
    public class TrainerAsign
    {
        public int TrainerAsignID { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        public string TopicID { get; set; }

        [Required]
        public string TrainerID { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual Trainer Trainer { get; set; }

    }
}
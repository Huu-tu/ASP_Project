using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Topic
    {
        public int TopicID { get; set; }
        [Required]
        [MaxLength(50)]
        public String TopicName { get; set; }

        public String TopicDescription { get; set; }
        

        public List<TrainerAsign> TrainerAsigns { get; set; }

        public static implicit operator Topic(string v)
        {
            throw new NotImplementedException();
        }
    }
}
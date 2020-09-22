using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Models
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Models
{
    public class Profile
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<int> Friends { get; set; }
        public List<Post> Posts { get; set; }

    }
}

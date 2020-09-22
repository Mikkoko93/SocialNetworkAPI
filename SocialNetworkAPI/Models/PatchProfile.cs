using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Models
{
    public class PatchProfile
    {
        public string ProfilePictureUrl { get; set; }
        public List<int> Friends { get; set; }

    }
}

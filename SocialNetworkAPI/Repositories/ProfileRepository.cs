using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using SocialNetworkAPI.Controllers;
using SocialNetworkAPI.Models;


namespace SocialNetworkAPI.Repositories
{
    public class ProfileRepository
    {
        private List<Profile> profiles;

        public ProfileRepository()
        {
            profiles = new List<Profile>();
            profiles = GetDummies();
        }

        public List<Profile> GetProfiles()
        {
            return profiles;
        }
        public Profile GetProfileId(int id)
        {
            
            return profiles.FirstOrDefault(c => c.ID == id);
        }

        public bool PatchProfileId(int profileId, JsonPatchDocument<PatchProfile> patchProfile)
        {
            Profile profile = GetProfileId(profileId);
            if (profile != null)
            {
                PatchProfile _patchProfile = new PatchProfile
                {
                    Friends = profile.Friends,
                    ProfilePictureUrl = profile.ProfilePictureUrl
                };
                patchProfile.ApplyTo(_patchProfile);
                profile.Friends = _patchProfile.Friends;
                profile.ProfilePictureUrl = _patchProfile.ProfilePictureUrl;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Profile> GetDummies()
        {
            List<Profile> dummyProfiles = new List<Profile>
            {
                new Profile
                {
                    ID = 0,
                    Name = "Johannes Kantola",
                    ProfilePictureUrl = "http://buuttiexample.com/kuva1.jpg",
                    Friends = new List<int>{1, 2},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "It was a beautiful day today."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "I made a cake!"
                        }
                    }
                },
                new Profile
                {
                    ID = 1,
                    Name = "Rene Orosz",
                    ProfilePictureUrl = "http://buuttiexample.com/kuva2.jpg",
                    Friends = new List<int>{0, 2},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "I made progress today."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "Feeling good..."
                        }
                    }
                },
                new Profile
                {
                    ID = 2,
                    Name = "Asiakas Assi",
                    ProfilePictureUrl = "http://buuttiexample.com/kuva3.jpg",
                    Friends = new List<int>{0, 1},
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            ID = 0,
                            Date = DateTime.Now,
                            Content = "Good morning."
                        },
                        new Post
                        {
                            ID = 1,
                            Date = DateTime.Now,
                            Content = "Making coffee."
                        }
                    }
                }
            };

            return dummyProfiles;
        }
    }
    
}

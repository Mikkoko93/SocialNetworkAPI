using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;

namespace SocialNetworkAPI.Repositories
{
    public class PostRepository
    {
        private ProfileRepository _profileRepository;

        public PostRepository(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public List<Post> GetPostsId(int id)
        {
            return _profileRepository.GetProfileId(id).Posts;
        }

        public Post GetProfilePostId(int profileId, int postId)
        {
            return _profileRepository.GetProfileId(profileId).Posts.FirstOrDefault(c => c.ID == postId);
        }
        
        public void AddPostProfile(int id, Post post)
        {
            Profile profile = _profileRepository.GetProfileId(id);

            post.Date = DateTime.Now;
            post.ID = GetLatestPost(profile.Posts);

            profile.Posts.Add(post);

        }
        public int GetLatestPost(List<Post> lPost)
        {
            return lPost.Last().ID++;
        }

        public bool DeleteProfilePost(int profileId, int postId)
        {
            List<Post> posts = GetPostsId(profileId);
            if (posts == null)
                return false;

            _profileRepository.GetProfileId(profileId).Posts = posts.Where(c => c.ID != postId).ToList();
            return true;
        }
    }
}

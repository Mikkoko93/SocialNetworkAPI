using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using SocialNetworkAPI.Models;


namespace SocialNetworkAPI.Controllers
{
    [Route("api/profile/{profileID:int}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _postRepository;

        public PostController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetPostsProfile(int id)
        {
            List<Post> posts = _postRepository.GetPostsId(id);
            return Ok(posts);

        }
        [HttpGet("{id}")]
        public ActionResult<Post> GetProfilePostId(int profileId, int postId)
        {
            Post post = _postRepository.GetProfilePostId(profileId, postId);
            return Ok(post);

        }

        [HttpPost]
        public IActionResult AddPost(int id, [FromBody] Post post)
        {
            _postRepository.AddPostProfile(id, post);
            return Created(Request.Path + "/" + id, post);
            
        }

        [HttpPatch("{id}")]
        public IActionResult PatchPostProfile(int profileId, int postId, [FromBody] JsonPatchDocument<PatchPost> patchPost)
        {
            Post post = _postRepository.GetProfilePostId(profileId, postId);

            PatchPost patchthisPost = new PatchPost
            {
                Content = post.Content
            };

            patchPost.ApplyTo(patchthisPost);
            post.Content = patchthisPost.Content;
            return NoContent();
        }
    }
}

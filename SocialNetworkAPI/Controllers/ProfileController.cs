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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileRepository _profileRepository;


        public ProfileController(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }


        [HttpGet]
        public ActionResult<List<Profile>> GetProfiles()
        {
            return Ok(_profileRepository.GetProfiles());
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfileId(int id)
        {
            Profile profile = _profileRepository.GetProfileId(id);

            if (profile != null)
            {
                return Ok(profile);
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProfileId(int id, [FromBody] JsonPatchDocument<PatchProfile> patchProfile)
        {
            if(_profileRepository.PatchProfileId(id, patchProfile))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

using APIProjectWithRedis.Models;
using APIProjectWithRedis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectWithRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repository;

        public PlatformController(IPlatformRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _repository.GetPlatformById(id);
            
            if(platform != null)
            {
                return Ok(platform);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform platform)
        {
            _repository.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platform.Id}, platform);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return Ok(_repository.GetAllPlatforms());
        }

        [HttpDelete]
        public ActionResult DeletePlatform(string id)
        {
            try
            {
                _repository.DeletePlatform(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
            
        }

        [HttpPut]
        public ActionResult UpdatePlatform(Platform platform)
        {
            try
            {
                _repository.UpdatePlatform(platform);
                return Ok(platform);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}

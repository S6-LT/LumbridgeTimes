using ImageUploadService.Services;
using Microsoft.AspNetCore.Mvc;
using ImageUploadService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageUploadService.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }
        // GET: api/<ImageController>
        [HttpGet]
        public ActionResult<List<Image>> Get()
        {
            return imageService.Get();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public ActionResult<Image> Get(string id)
        {
            var image = imageService.Get(id);
            if (image == null)
            {
                return NotFound("image not found");
            }
            return image;
        }

        // POST api/<ImageController>
        [HttpPost]
        public ActionResult<Image> Post([FromBody] Image image)
        {
            imageService.Create(image);

            return CreatedAtAction(nameof(Get), new { id = image.id }, image);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Image image)
        {
            var existingImage = imageService.Get(id);
            if (existingImage == null)
            {
                return NotFound("image not found");
            }

            imageService.Update(id, image);

            return NoContent();
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var image = imageService.Get(id);

            if (image == null)
            {
                return NotFound("image not found");
            }

            imageService.Remove(image.id);

            return Ok("image deleted");
        }
    }
}

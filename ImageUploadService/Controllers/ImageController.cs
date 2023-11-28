using ImageUploadService.Services;
using Microsoft.AspNetCore.Mvc;
using ImageUploadService.Model;
using ImageUploadService.RabbitMQ;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageUploadService.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        private readonly IRabitMQProducer _rabbitMQProducer;
        public ImageController(IImageService imageService, IRabitMQProducer rabbitMQProducer)
        {
            this.imageService = imageService;
            _rabbitMQProducer = rabbitMQProducer;
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
            _rabbitMQProducer.SendProductMessage(image);

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

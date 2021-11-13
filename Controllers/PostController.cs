using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostParcelsAPI.Dtos;
using PostParcelsAPI.Models;
using PostParcelsAPI.Services;

namespace PostParcelsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        public PostController(PostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _postService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePostDto postDto)
        {
            return Ok(await _postService.CreateAsync(postDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Post post)
        {
            await _postService.UpdateAsync(id, post);
            return Ok();
        }

    }
}

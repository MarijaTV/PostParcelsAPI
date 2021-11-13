using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostParcelsAPI.Dtos;
using PostParcelsAPI.Services;

namespace PostParcelsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _parcelService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _parcelService.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("ParcelsByPost/{postId}")]
        public async Task<ActionResult> GetByPostId(int postId)
        {
            var parcels = await _parcelService.GetByPostIdAsync(postId);
            return Ok(parcels);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateParcelDto parcelDto)
        {
            return Ok(await _parcelService.CreateAsync(parcelDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _parcelService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateParcelDto parcelDto)
        {
            await _parcelService.UpdateAsync(parcelDto);
            return Ok();
        }
    }
}

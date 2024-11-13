using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNumberController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public PhoneNumberController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return BadRequest("Phone number is required.");

            var result = await _countryService.GetCountryByPhoneNumberAsync(phoneNumber);
            if (result == null)
                return NotFound("Country not found for the provided phone number.");

            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);

            return Ok(result);
        }
    }
}

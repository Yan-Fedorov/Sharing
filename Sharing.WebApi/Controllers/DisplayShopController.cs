using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sharing.Business.Interfaces;

namespace Sharing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayShopController : ControllerBase
    {
        private readonly IDisplayShopService _displayShopService;

        public DisplayShopController(IDisplayShopService displayShopService)
        {
            _displayShopService = displayShopService;
        }

        [HttpGet("machines")]
        public async Task<IActionResult> GetAllMachines()
        {
            var result = _displayShopService.DisplayAllMachines();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Empty machines list");
        }

        [Authorize]
        [HttpGet("availableMachines/{id}")]
        public IActionResult GetAvailableMachines(int id)
        {
            try
            {
                var result = _displayShopService.DisplayAllAvailableMachines(id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest("Empty machines list");
            }

            return BadRequest("Empty machines list");
        }
    }
}
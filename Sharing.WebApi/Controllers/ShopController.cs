using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharing.Business.Interfaces;

namespace Sharing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<IActionResult> RenterMachine(int renterId, int machineId, DateTime startTime, DateTime endTime)
        {
            if (renterId < 1 || machineId < 1 || startTime == new DateTime() || endTime == DateTime.Now ||
                endTime == new DateTime())
            {
                return BadRequest("Something wrong with Parameters");
            }

            try
            {
                var result = _shopService.RenterMachine(renterId, machineId, startTime, endTime);

                if (result >= 1)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception exception)
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
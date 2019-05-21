using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> RenterMachine([FromBody] RentDto rentDto)
        {
            var startTime = new DateTime(rentDto.StartDate.Year, rentDto.StartDate.Month, rentDto.StartDate.Day);
            var endTime = new DateTime(rentDto.EndDate.Year, rentDto.EndDate.Month, rentDto.EndDate.Day);
            if (rentDto.RenterId < 1 || rentDto.MachineId < 1 || startTime == new DateTime() || endTime == DateTime.Now ||
                endTime == new DateTime())
            {
                return BadRequest("Something wrong with Parameters");
            }

            try
            {
                var result = _shopService.RenterMachine(rentDto.RenterId, rentDto.MachineId, startTime, endTime);

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
    public class NgbDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
       
        public NgbDate()
        {

        }
    }
    public class RentDto
    {
        public int RenterId { get; set; }
        public int MachineId { get; set; }
        public NgbDate StartDate { get; set; }
        public NgbDate EndDate { get; set; }
        public RentDto()
        {

        }
    }
}
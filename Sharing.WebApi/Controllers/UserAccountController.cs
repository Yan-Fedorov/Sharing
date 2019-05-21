using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharing.Business;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;

namespace Sharing.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        
        [HttpGet("renter/{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public IActionResult GetRenterAccount(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less then 1");
            }

            try
            {
                var result = _userAccountService.GetRenterAccount(id);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("id is less then 1");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [ProducesResponseType(typeof(RenteredResource), StatusCodes.Status200OK)]
        [HttpGet("renteredMachine/{id}")]
        public IActionResult GetRenteredMachine(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less then 1");
            }

            try
            {
                var result = _userAccountService.GetRenteredMachineAccount(id);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("id is less then 1");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("activateDron/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ActivateDron(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less then 1");
            }
            try
            {
                var result = _userAccountService.ActivateDron(id);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("id is less then 1");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("activateDronByString/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ActivateDron(string id)
        {
            int requestedId;
            int.TryParse(id, out requestedId);

            if (requestedId < 1)
            {
                return BadRequest("id is less then 1");
            }
            try
            {
                var result = _userAccountService.ActivateDron(requestedId);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("id is less then 1");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        

        [HttpPost("renter")]
        public async Task<IActionResult> ChangeRenterAccount(Customer renter)
        {
            if (renter == null)
            {
                return BadRequest(nameof(renter));
            }

            try
            {
                var result = _userAccountService.ChangeRenterAccount(renter);
                if (result)
                {
                    return Ok();
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(renter));
            }
            catch (Exception exception)
            {
                return StatusCode(500);
            }
            return StatusCode(500);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRenterAccount(int id)
        {
            if (id < 1)
            {
                return BadRequest(nameof(id));
            }

            try
            {
                var result = _userAccountService.DeleteRenterAccount(id);
                if (result)
                {
                    return Ok();
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return StatusCode(500);
        }
    }
}
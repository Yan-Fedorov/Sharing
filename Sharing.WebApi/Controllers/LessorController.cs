using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharing.Business;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;

namespace Sharing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public LessorController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("lessor")]
        public IActionResult ChangeLessorAccount(Lessor lessor)
        {
            if (lessor == null)
            {
                return StatusCode(400);
            }
            try
            {
                var result = _userAccountService.ChangeLessorAccount(lessor);
                if (result)
                {
                    return Ok();
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(lessor));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return StatusCode(500);
        }
        [HttpGet("lessor")]
        public async Task<IActionResult> GetLessorAccount(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less then 1");
            }

            try
            {
                var result =  _userAccountService.GetLessorAccount(id);
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
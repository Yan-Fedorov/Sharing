using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IRepository<CloudResource> _machineService;
        private readonly IUserAccountService _userAccountService;
        private readonly IRepository<Lessor> _lessorRepository;

        public MachineController(IRepository<CloudResource> machineService, IUserAccountService userAccountService, IRepository<Lessor> lessorRepository)
        {
            _machineService = machineService;
            _lessorRepository = lessorRepository;
        }
        [Authorize]
        [HttpPost]
        public IActionResult ChangeMachine(CloudResource machine)
        {
            if (machine == null)
            {
                return StatusCode(400);
            }
            try
            {
                var result = _machineService.Update(machine);
                if (result >= 1)
                {
                    return Ok();
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(machine));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return StatusCode(500);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CloudResource), StatusCodes.Status200OK)]
        public IActionResult GetMachine(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less then 1");
            }

            try
            {
                var result = _machineService.GetItem(id);
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

        [HttpGet("getMachines")]
        public IActionResult GetMachines()
        {
            try
            {
                var result = _machineService.GetItemList();
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

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteMachine(int id)
        {
            if (id < 1)
            {
                return BadRequest(nameof(id));
            }

            try
            {
                var result = _machineService.Delete(id);
                if (result >= 1)
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

        [Authorize]
        [HttpPost("create")]
        public IActionResult CreateMachine(CloudResource machine)
        {
            if (machine == null)
            {
                return BadRequest(nameof(machine));
            }

            try
            {
                machine.Lessor = _lessorRepository.GetItem(machine.Lessor.Id);
                var result = _machineService.Create(machine);
                if (result >= 1)
                {
                    return Ok();
                }
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(machine));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return StatusCode(500);
        }

    }
}
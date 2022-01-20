using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Services;
using TaggerAppBE.Utilities;

namespace TaggerAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/authenticate")]
        public IActionResult Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("/user/create")]
        public IActionResult Create([FromBody] UserRequestDTO user, [FromQuery] string role)
        {
            var response = _userService.Create(user, role);
            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet("/users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
    }
}

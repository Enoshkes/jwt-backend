﻿using jwt_rest.Dto;
using jwt_rest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace jwt_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IJwtService jwtService) : ControllerBase
    {
        private static readonly ImmutableList<string> allowedNames = [
            "enosh", "avi"
        ];

        [HttpPost]
        public ActionResult<string> Login([FromBody] LoginDto loginDto) =>
            allowedNames.Contains(loginDto.Name)
                ? Ok(jwtService.CreateToken(loginDto.Name))
                : BadRequest();

        [Authorize]
        [HttpGet("protected")]
        public ActionResult<string> Protected()
        {
            return Ok("Yay!!");
        }
    }
}

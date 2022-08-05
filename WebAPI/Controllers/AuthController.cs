using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        IAuthService authService;

        [HttpPost("login")]
        public ActionResult login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = authService.Login(userForLoginDto);
            if (userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("register")]
        public ActionResult register(UserForRegisterDetailDto userForRegisterDetailDto)
        {
            var userExists = authService.UserExists(userForRegisterDetailDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = authService.Register(userForRegisterDetailDto,userForRegisterDetailDto.Password);
            var result = authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}

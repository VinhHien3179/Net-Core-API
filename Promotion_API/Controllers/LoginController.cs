using Promotion.Application.Extensions;
using Promotion.Application.Interfaces;
using Promotion.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Collections.Generic;
using Promotion.Model.Model.Comon;
using System.Collections;
using System.Security.Claims;
using Promotion.Application.Services;
using Twilio.TwiML.Messaging;

namespace Promotion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginService _logService;
        public LoginController(IConfiguration config, ILoginService logService)
        {
            _config = config;
            _logService = logService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            IActionResult response = Unauthorized();
            string result = _logService.LoginUser(userLogin.Username, userLogin.Password);
            if (result != null)
            {
                //var tokenString = GenerateJSONWebToken(userLogin);
                response = Ok(new { token = "Bearer "+result });
            }
            else
            {
                response = BadRequest(new { Message = "Email or Password is incorrect" });
            }

            return response;
        }

        [HttpGet]
        [Route("getJWTClaim")]
        public IActionResult getJWTClaim(string token)
        {
            IActionResult response = Unauthorized();
            var result = _logService.getJWTTokenClaim(token);
            if (result != null)
            {
                //var tokenString = GenerateJSONWebToken(userLogin);
                response = Ok(new { token = result });
            }

            return response;
        }
    }

}

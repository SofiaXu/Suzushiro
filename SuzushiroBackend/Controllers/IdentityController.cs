using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuzushiroBackend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuzushiroBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private UserManager<UserModel> _userManager;
        private IOptions<JsonWebTokenModel> _jwtoptions;

        public IdentityController(UserManager<UserModel> userManager, IOptions<JsonWebTokenModel> jwtoptions)
        {
            _userManager = userManager;
            _jwtoptions = jwtoptions;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public JsonResult SignIn(SignInModel signIn)
        {
#if DEBUG
            
#endif
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, signIn.Username),
            };

            var token = new JwtSecurityToken(
               issuer: _jwtoptions.Value.Issuer,
               audience: _jwtoptions.Value.Audience,
               claims: claims,
               notBefore: DateTime.Now,
               expires: DateTime.Now.AddMinutes(_jwtoptions.Value.AccessExpiration),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtoptions.Value.Secert)), SecurityAlgorithms.HmacSha256));

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new JsonResult(new SignInViewModel
            {
                Message = "success",
                StateCode = 200,
                Token = jwt,
                Username = signIn.Username,
            });
        }

        [HttpGet("GetUserInformation")]
        public JsonResult GetUserInformation()
        {
            var username = User.FindFirst(ClaimTypes.Name).Value;
#if DEBUG
            return new JsonResult(new UserInformationViewModel
            {
                StateCode = 200,
                Email = "aoba@aobaraws.com",
                Message = "success",
                Telephone = "13311111111",
                UserId = 1,
                UserAvatar = "https://i.loli.net/2020/09/01/STKzYxDmgq4Zpt1.jpg",
                Username = username
            });
#endif
        }
    }
}

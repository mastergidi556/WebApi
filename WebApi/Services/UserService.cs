using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Shared;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginUserModel user)
        {
            var userDb = await _userManager.FindByEmailAsync(user.Email);

            if(userDb == null)
            {
                return new UserManagerResponse
                {
                    Message = "No User with this email address",
                    isSuccess = false,
                };
            }

            var result =await  _userManager.CheckPasswordAsync(userDb, user.Password);

            if(!result)
            {
                return new UserManagerResponse
                {
                    Message = "Wrong password",
                    isSuccess = false
                };
            }

            var claims = new[]
            {
                new Claim("Email",user.Email),
                new Claim(ClaimTypes.NameIdentifier, userDb.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims:claims,
                expires:DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                isSuccess = true,
                Expiration = token.ValidTo
            };

        }


        public async Task<object> RegisterUserAsync(User model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return new { Message = "User created successfully" };
            }

            return result.Errors.Select(e => e.Description);

        }
    }
}

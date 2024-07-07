using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly RoleManager<Roles> _roleManager;


        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config, RoleManager<Roles> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager;
        }
        public async Task<string> Authecate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.PasswordHash, request.Rememberme, true);
            if (!result.Succeeded)
            { return null; }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.PostalCode, request.PasswordHash),
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new User
            {
               UserName = request.Username.Trim(),
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                FirstName = request.FirstName,
                LastName = request.LastName,
               
            };
           var result = await _userManager.CreateAsync(user, request.PasswordHash);
            if (result.Succeeded)
            {
                return true;
            }
            return false;

        }
    }
}

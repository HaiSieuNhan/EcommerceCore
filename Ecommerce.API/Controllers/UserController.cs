﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Portal.Infrastructure.Helper;
using Ecommerce.Portal.Infrastructure.Wrappers;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Portal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly AuthencationSetting _authencationSetting;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IOptions<AuthencationSetting> authencationSetting, IMapper mapper)
        {
            _userService = userService;
            _authencationSetting = authencationSetting.Value;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ApiResponse> Login([FromBody] UserLoginDto userDto)
        {
            //var user = await _userService.Authenticate(userDto.Username, userDto.Password, userDto.SessionId);

            //if (user == null)
            //    throw new ApiException("Tên đăng nhập hoặc mật khẩu không chính xác", 200);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authencationSetting.Secret);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "SyNV"),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new ApiResponse("Token", tokenString, 200);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ApiResponse Register([FromBody] UserDto userDto)
        {
            return null;
        }
        [Authorize(Roles = "Admin")]
        [Route("get-all-user")]
        [HttpGet]
        public async Task<ApiResponse> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return new ApiResponse("list user", userDtos, 200);
        }


        [HttpGet("get-user-by-id/{name}")]
        public async Task<ApiResponse> GetUserByUserName(string username)
        {
            try
            {
                var user = await _userService.FindAsync(c => c.Username == username);
                if (user == null)
                {
                    return new ApiResponse("Can't find user with name", username, 200);
                }

                // var currentUserId = Guid.Parse(User.Identity.Name);
                if (!User.IsInRole("Admin"))
                {
                    return new ApiResponse("forbidden", username, 403);
                }

                var userDto = _mapper.Map<UserDto>(user);
                return new ApiResponse("user detail", userDto, 200);
            }
            catch (Exception ex)
            {
                return new ApiResponse("Can't get user infomation", ex, 400);
            }
        }

        [HttpPut("{id}")]
        public ApiResponse UpdateUser(int id, [FromBody] UserDto userDto)
        {
            return null;
        }

        [HttpDelete("delete-user/{id}")]
        public ApiResponse DeleteUser(Guid id)
        {
            return null;
        }

    }
}
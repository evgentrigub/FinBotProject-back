using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Entities.ModelViews;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            DataContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Id,
                user.Username,
                user.FirstName,
                user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);

            try
            {
                // save 
                _userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new {message = ex.Message});
            }
        }

        [AllowAnonymous]
        [HttpPut("addMoney/{id}")]
        public IActionResult AddMoneyToAccount(User user)
        {
            if (user.Account < 0) return BadRequest(new {message = "Неккоректно заполнено поле"});
            try
            {
                _userService.UpdateAccount(user);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpGet("stat/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Where(r => r.Id == id).Include(a => a.TradingBots).SingleOrDefault();
            var userStats = new StatsModelView
            {
                Profit = user.TradingBots.Sum(r => r.Profit),
                RiskType = user.RiskType,
                Account = user.Account,
                RobotsQuantity = user.TradingBots.Count
            };
            return Ok(userStats);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
using Lesson27Task.Data.Entities;
using Lesson27Task.DTO;
using Lesson27Task.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;

namespace Lesson27Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        public ProductController(IProductService productService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _productService = productService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = configuration;
        }
        [HttpPost("Register")]
        public async Task Register(string email, string name, string password)
        {
            var user = new IdentityUser { UserName = name, Email = email };
            var result = await _userManager.CreateAsync(user, password);
        }
        [HttpGet]
        [Route("Login")]
        public async Task<List<string>> Login(string email, string password)
        {
            List<string> result = new List<string>();
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                await _signInManager.PasswordSignInAsync(user.UserName, password, false, true);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Add(tokenHandler.WriteToken(token));
            return result;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Addroletouser")]
        public async Task<IActionResult> AddRoleToUser(string user_id, string role_id)
        {
            var user = await _userManager.FindByIdAsync(user_id);
            var role = await _roleManager.FindByIdAsync(role_id);
            if (user != null && role != null)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return Ok();
            }
            return BadRequest();
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("AddRole")]
        public async Task AddRole(string rolename)
        {
            var role = new IdentityRole { Name = rolename };
            var result = await _roleManager.CreateAsync(role);
        }
        [Authorize]
        [HttpGet]
        public ResponseModel<IEnumerable<Product>> Get()
        {
            var data = _productService.Get();
            return data;
        }
        [Authorize(Policy = "AllowAnonymous")]
        [HttpPost]
        public ResponseModel<Product> Post([FromQuery] ProductDTO model)
        {
            var data = _productService.Post(model);
            return data;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseModel<Product> Delete([FromRoute] int id)
        {

            var data = _productService.Delete(id);
            return data;
        }
        [HttpPut]
        [Route("Put/{id}")]
        public ResponseModel<Product> Put([FromRoute] int id, ProductDTO model)
        {
            var data = _productService.Update(id, model);
            return data;
        }
        [AllowAnonymous]
        [HttpPost("GetUsersWithoutEmail")]
        public List<int> GetUsersWithoutEmail([FromQuery]string jsonString)
        {
            List<int> unregisteredIds = new List<int>();
            UserData data = Newtonsoft.Json.JsonConvert.DeserializeObject<UserData>(jsonString);
            foreach (UserJson user in data.Users)
            {
                if (string.IsNullOrEmpty(user.Email))
                {
                    unregisteredIds.Add(user.Id);
                }
            }
            return unregisteredIds;
        }
    }
}

using AutoMapper;
using Magnum.FileSystem;
using Marmara.Api.DTOs;
using Marmara.Api.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;
        public AuthenticateController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IConfiguration configuration,IMapper mapper, IHostingEnvironment environment)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok(new Response { Status = "LogOut", Message = "Çıkış yapıldı." });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, UserRoles.User);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            if (model.File!=null)
            {
                {
                    {
                        var extention = Path.GetExtension(model.File.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        user.image = randomName;
                        var path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await model.File.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }
            }

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            /*
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
               if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            */
            await userManager.AddToRoleAsync(user, UserRoles.Admin);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        public FileResult GetFile(string imageName)
        {
            string path = Path.Combine(_environment.WebRootPath, "images/") + imageName;
            FileStream image = System.IO.File.OpenRead(path);
            return File(path, "image/png", imageName);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserInfo(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var user_dto = _mapper.Map<UserDto>(user);
            user_dto.File = GetFile(user_dto.image);
            return Ok(user_dto);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update(User user)
        {
            User updated_user = userManager.FindByIdAsync(user.Id).Result;
            updated_user.Name = user.Name;
            updated_user.Surname = user.Surname;
            updated_user.PhoneNumber = user.PhoneNumber;
            updated_user.Email = user.Email;
            updated_user.Birthday = user.Birthday;
            var result = userManager.UpdateAsync(updated_user).Result;
            return NoContent();
        }

        [Authorize]
        [HttpPut("{apiname}",Name ="ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            var user = userManager.FindByIdAsync(model.Id).Result;
            string token = userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = userManager.ResetPasswordAsync(user, token, model.Password).Result;
            if (result.Succeeded)
            {
                return NoContent();
            }
            return Ok(new Response { Status = "Hata", Message = "Parola değiştirilemedi." });
        }
    }
}
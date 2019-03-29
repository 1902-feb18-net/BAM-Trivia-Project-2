using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BAMTriviaProject2.DAL;
using BAMTriviaProject2.WebAPI.AuthModels;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace BAMTriviaProject2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUsersRepo usersRepo { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersRepo newUsersRepo, 
            SignInManager<IdentityUser> signInManager,
            AuthDbContext dbContext,
            ILogger<UsersController> logger)
        {
            usersRepo = newUsersRepo;
            SignInManager = signInManager;
            _logger = logger;

            dbContext.Database.EnsureCreated();

        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public AuthAccountDetails Details()
        {
            // if we want to know which user is logged in or which roles he has
            // apart from [Authorize] attribute...
            // we have User.Identity.IsAuthenticated
            // User.IsInRole("admin")
            // User.Identity.Name
            if (!User.Identity.IsAuthenticated)
            {
                //_logger.LogInformation("");
                return null;
            }
            var details = new AuthAccountDetails
            {
                Username = User.Identity.Name,
                AccountType = User.IsInRole("admin"),
                Roles = User.Claims.Where(c => c.Type == ClaimTypes.Role)
                                   .Select(c => c.Value)
            };
            return details;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthLogin login)
        {
            SignInResult result = await SignInManager.PasswordSignInAsync(
                login.Username, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                return Unauthorized(); // 401 for login failure
            }

            return NoContent();
        }

        // POST /account/logout
        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return NoContent();
        }

        // POST /account
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AuthRegister register,
            [FromServices] RoleManager<IdentityRole> roleManager,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser(register.Username);

            IdentityResult createUserResult = await userManager.CreateAsync(user,
                register.Password);

            if (!createUserResult.Succeeded) // e.g. did not meet password policy
            {
                return BadRequest(createUserResult);
            }

            if (register.AccountType == true)
            {
                // make sure admin role exists
                if (!await roleManager.RoleExistsAsync("admin"))
                {
                    var role = new IdentityRole("admin");
                    IdentityResult createRoleResult = await roleManager.CreateAsync(role);
                    if (!createRoleResult.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "failed to create admin role");
                    }
                }

                // add user to admin role
                IdentityResult addRoleResult = await userManager.AddToRoleAsync(user, "admin");
                if (!addRoleResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to add user to admin role");
                }
            }

            await SignInManager.SignInAsync(user, false);

            await usersRepo.AddAsync(new UsersModel
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                PW = "a",
                Username = register.Username,
                CreditCardNumber = register.CreditCardNumber,
                PointTotal = 0,
                AccountType = register.AccountType
            });

            return NoContent(); // nothing to show the user that he can access
        }


        // GET: api/TUsers
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/TUsers/5
        [HttpGet("{id}", Name = "GetById")]
        //[Produces("application/xml")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsersModel> GetById(int id)
        {
            //if (_data.FirstOrDefault(x => x.Id == id) is var character)
            //{
            //    return character;
            //}

            //return NotFound();

            return usersRepo.GetUserById(id);
        }

        // POST: api/TUsers
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/TUsers/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        
    }
}

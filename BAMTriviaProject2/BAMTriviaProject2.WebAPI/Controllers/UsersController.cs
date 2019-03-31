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
    [AllowAnonymous]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUsersRepo _usersRepo { get; set; }
        public IUserQuizzesRepo _userQuizzesRepo { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersRepo newUsersRepo, 
            IUserQuizzesRepo newUserQuizzesRepo,
            SignInManager<IdentityUser> signInManager,
            AuthDbContext dbContext,
            ILogger<UsersController> logger)
        {
            _usersRepo = newUsersRepo;
            _userQuizzesRepo = newUserQuizzesRepo;
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
                UserId = _usersRepo.GetUserId(User.Identity.Name),
                Username = User.Identity.Name,
                AccountType = User.IsInRole("admin"),
                Roles = User.Claims.Where(c => c.Type == ClaimTypes.Role)
                                   .Select(c => c.Value)
            };
            return details;
        }

        [HttpGet]
        [Route("Account")]
        public UsersModel GetDetails()
        {
            if (!User.Identity.IsAuthenticated)
            {
                //_logger.LogInformation("");
                return null;
            }
            UsersModel details = _usersRepo.GetUserById(_usersRepo.GetUserId(User.Identity.Name));
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
        [AllowAnonymous]
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

            await _usersRepo.AddAsync(new UsersModel
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

        // GET: api/TUsers/5
        [HttpGet("{id}", Name = "GetById")]
        //[Produces("application/xml")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsersModel> GetById(int id)
        {
            return _usersRepo.GetUserById(id);
        }

        [HttpPost]
        [Route("{id}/Quizzes/")]
        public async Task<ActionResult> UserQuiz(int id, [FromBody] UserQuizzesModel userQuizzesModel)
        {
            //UsersModel currentUser = await _usersRepo.GetUserByName(userQuizzesModel.Username);

            //int lastUserQuizId = await _userQuizzesRepo.AddUserQuiz(userQuizzesModel);
            await _userQuizzesRepo.AddUserQuiz(userQuizzesModel);

            //int lastUserQuizId = await _userQuizzesRepo.GetLastUserQuizId(id);
            userQuizzesModel.UserId = id;
            //userQuizzesModel.UserQuizId = lastUserQuizId;
            userQuizzesModel.QuizDate = DateTime.Now;

            await _userQuizzesRepo.AddUserQuiz(userQuizzesModel);

            return CreatedAtAction(nameof(UserQuiz), userQuizzesModel);
        }

        [HttpPut]
        public async Task<ActionResult> EditUser([FromBody] UsersModel usersModel)
        {
            //UsersModel currentUser = _usersRepo.GetUserByName(usersModel.Username);

            //currentUser.FirstName = usersModel.FirstName;
            //currentUser.LastName = usersModel.LastName;
            //currentUser.CreditCardNumber = usersModel.CreditCardNumber;

            await _usersRepo.EditUserAsync(usersModel);

            return CreatedAtAction(nameof(UserQuiz), usersModel);
        }
    }
}

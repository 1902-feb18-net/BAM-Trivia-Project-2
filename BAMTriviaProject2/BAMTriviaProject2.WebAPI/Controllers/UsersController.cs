using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BAMTriviaProject2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUsersRepo newUsersRepo, ILogger<UsersController> logger)
        {
            usersRepo = newUsersRepo;
            _logger = logger;
        }

        public IUsersRepo usersRepo { get; set; }

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

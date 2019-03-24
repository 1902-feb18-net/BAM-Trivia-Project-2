using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class UsersRepo : IUsersRepo
    {



        private readonly ILogger<UsersRepo> _logger;
        public static BAMTriviaProject2Context Context { get; set; }

        public UsersRepo(BAMTriviaProject2Context dbContext, 
            ILogger<UsersRepo> logger)
        {
            Context = dbContext;
            _logger = logger;

        }

        public UsersModel GetUserById(int id)
        {
            try
            {
                return Mapper.Map(Context.Tusers.Single(u => u.UserId == id));
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> list = new List<UsersModel>();
            return list;
        }

        public async Task<UsersModel> AddAsync(UsersModel user)
        {
            Context.Tusers.Add(Mapper.Map(user));
            await Context.SaveChangesAsync();

            return user;
        }

    }
}

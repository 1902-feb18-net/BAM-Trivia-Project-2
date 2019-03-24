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
        private readonly IMapper _mapper;

        public static BAMTriviaProject2Context Context { get; set; }

        public UsersRepo(BAMTriviaProject2Context dbContext, 
            ILogger<UsersRepo> logger, IMapper mapper)
        {
            Context = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public UsersModel GetUserById(int id)
        {
            try
            {
                return _mapper.Map(Context.Tusers.Single(u => u.UserId == id));
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
            Context.Tusers.Add(_mapper.Map(user));
            await Context.SaveChangesAsync();

            return user;
        }

    }
}

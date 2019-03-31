using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.EntityFrameworkCore;
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

        public BAMTriviaProject2Context Context { get; set; }

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

        public int GetUserId(string name)
        {
            try
            {
                return _mapper.Map(Context.Tusers.Single(u => u.Username == name)).UserId;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return 0;
            }
        }

        public async Task<UsersModel> GetUserByName(string username)
        {
            try
            {
                return _mapper.Map(await Context.Tusers.SingleAsync(u => u.Username == username));
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
            await SaveChangesAndCheckException();

            return user;
        }

        public async Task<UsersModel> EditUserAsync(UsersModel user)
        {
            var entity = await Context.Tusers.FindAsync(user.UserId);
            Context.Entry(entity).CurrentValues.SetValues(_mapper.Map(user));
            await SaveChangesAndCheckException();

            return user;
        }

        public async Task<int> SaveChangesAndCheckException()
        {
            try
            {
                await Context.SaveChangesAsync();
                return 0;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
        }

    }
}

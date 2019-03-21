using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        public static BAMTriviaProject2Context Context { get; set; }

        public UsersRepo(BAMTriviaProject2Context dbContext)
        {
            Context = dbContext;
        }

        public UsersModel GetUserById(int id)
        {
            //UsersModel m = new UsersModel();
            return Mapper.Map(Context.Tusers.Single(u => u.UserId == id));
        }

        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> list = new List<UsersModel>();
            return list;
        }
    }
}

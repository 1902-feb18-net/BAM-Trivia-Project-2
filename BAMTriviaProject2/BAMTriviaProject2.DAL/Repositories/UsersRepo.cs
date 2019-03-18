using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        public UsersModel GetUserById(int id)
        {
            UsersModel m = new UsersModel();
            return m;
        }

        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> list = new List<UsersModel>();
            return list;
        }
    }
}

using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IUsersRepo
    {
        UsersModel GetUserById(int id);

        List<UsersModel> GetAllUsers();
    }
}

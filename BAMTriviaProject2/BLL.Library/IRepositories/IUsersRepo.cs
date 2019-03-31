using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IUsersRepo
    {
        int GetUserId(string name);
        UsersModel GetUserById(int id);
        Task<UsersModel> GetUserByName(string name);
        List<UsersModel> GetAllUsers();
        Task<UsersModel> AddAsync(UsersModel user);
        Task<UsersModel> EditUserAsync(UsersModel user);
    }
}

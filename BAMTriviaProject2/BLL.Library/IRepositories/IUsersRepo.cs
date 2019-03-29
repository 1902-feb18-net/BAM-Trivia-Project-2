﻿using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IUsersRepo
    {
        UsersModel GetUserById(int id);
        UsersModel GetUserByName(string name);
        List<UsersModel> GetAllUsers();
        Task<UsersModel> AddAsync(UsersModel user);
    }
}

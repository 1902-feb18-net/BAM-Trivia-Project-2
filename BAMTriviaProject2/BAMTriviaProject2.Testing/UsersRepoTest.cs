using BAMTriviaProject2.DAL;
using BAMTriviaProject2.DAL.Repositories;
using BAMTriviaProject2.WebAPI.AuthModels;
using BAMTriviaProject2.WebAPI.Controllers;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BAMTriviaProject2.Testing
{
    public class UsersRepoTest
    {
        [Fact]
        public async void AddUserAsync()
        {
            // Arrange

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<BAMTriviaProject2Context>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new BAMTriviaProject2Context(options))
                {
                    context.Database.EnsureCreated();
                    IMapper mapper = new Mapper();

                    UsersModel newUser = new UsersModel
                    {
                        FirstName = "Bob1234kfh",
                        LastName = "Jonesasdfs3",
                        PW = "a",
                        Username = "bJonesOreoCookie",
                        CreditCardNumber = 2,
                        PointTotal = 0,
                        AccountType = false
                    };

                    context.Tusers.Add(mapper.Map(newUser));
                    var user = context.Tusers
                        .Where(u => u.Username == "bJonesOreoCookie");

                    Assert.True(user != null);

                }



            }
            finally
            {
                connection.Close();
            }
        }
    }
}

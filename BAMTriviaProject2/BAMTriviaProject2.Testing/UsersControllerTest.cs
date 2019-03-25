using BAMTriviaProject2.DAL;
using BAMTriviaProject2.WebAPI.AuthModels;
using BAMTriviaProject2.WebAPI.Controllers;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BAMTriviaProject2.Testing
{
    public class UsersControllerTest
    {
        //[Fact]
        //public async void AddUserAsync()
        //{
        //    // Arrange
        //    UsersModel newUser = new UsersModel
        //    {
        //        FirstName = "Bob1234kfh",
        //        LastName = "Jonesasdfs3",
        //        PW = "a",
        //        Username = "bJonesOreoCookie",
        //        CreditCardNumber = 2,
        //        PointTotal = 0,
        //        AccountType = false
        //    };

        //    var mockRepo = new Mock<IUsersRepo>();
        //    mockRepo.Setup(x => x.AddAsync(newUser));
        //    var signInManager = new FakeSignInManager();
        //    var mockAuth = Mock.Of<AuthDbContext>();
        //    ILogger<UsersController> logger = Mock.Of<ILogger<UsersController>>();
           
        //    var sut = new UsersController(mockRepo.Object,
        //        signInManager, mockAuth, logger);

        //    AuthRegister newAuthUser = new AuthRegister
        //    {
        //        FirstName = "Bob1234kfh",
        //        LastName = "Jonesasdfs3",
        //        Username = "bJonesOreoCookie",
        //        Password = "a",
        //        CreditCardNumber = 2,
        //        AccountType = false
        //    };

        //    var roleInManager = new FakeRoleManager();
        //    var userManager = new FakeUserManager();

        //    // Act

        //    await sut.Register(newAuthUser, roleInManager, userManager);


        //    // use a sqllite database for authdb



        //    // Assert
        //    // Call register, and assert that usermanager.userexists and has password
        //    var user = await userManager.FindByNameAsync("bJonesOreoCookie");
        //    Assert.True(user != null);

        //    Assert.True(true);


        //    //IEnumerable<ApiCharacter> result = sut.Get();

        //    //var resultList = result.ToList();

        //    //Assert.Equal(characters.Count, resultList.Count);
        //    //    for (var i = 0; i<resultList.Count; i++)
        //    //    {
        //    //        Assert.Equal(characters[i].Id, resultList[i].Id);
        //    //        Assert.Equal(characters[i].Name, resultList[i].Name);
        //    //    }
        //}

        // https://stackoverflow.com/questions/48189741/mocking-a-signinmanager/54558958
        public class FakeSignInManager : SignInManager<IdentityUser>
        {
            public FakeSignInManager()
                : base(new Mock<FakeUserManager>().Object,
                      new HttpContextAccessor(),
                      new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                      new Mock<IAuthenticationSchemeProvider>().Object)
            { }
        }

        public class FakeUserManager : UserManager<IdentityUser>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<IdentityUser>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<IdentityUser>>().Object,
                      new IUserValidator<IdentityUser>[0],
                      new IPasswordValidator<IdentityUser>[0],
                      new Mock<ILookupNormalizer>().Object,
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<IdentityUser>>>().Object)
            { }
        }

        public class FakeRoleManager : RoleManager<IdentityRole>
        {
            public FakeRoleManager()
                : base(new Mock<IRoleStore<IdentityRole>>().Object,
                     new Mock<IEnumerable<IRoleValidator<IdentityRole>>>().Object,
                     new Mock<ILookupNormalizer>().Object,
                     new Mock<IdentityErrorDescriber>().Object,
                     new Mock<ILogger<RoleManager<IdentityRole>>>().Object)
            { }
        }
    }
}

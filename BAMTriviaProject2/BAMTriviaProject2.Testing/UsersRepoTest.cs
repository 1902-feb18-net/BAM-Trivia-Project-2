using BAMTriviaProject2.DAL;
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
using Xunit;

namespace BAMTriviaProject2.Testing
{
//    public class UsersRepoTest
//    {


//        [Fact]
//        public void AddUserAsync()
//        {
//            UsersModel newUser = new UsersModel
//            {
//                FirstName = "Bob1234kfh",
//                LastName = "Jonesasdfs3",
//                PW = "a",
//                Username = "bJonesOreoCookie",
//                CreditCardNumber = 2,
//                PointTotal = 0,
//                AccountType = false
//            };

//            var mockRepo = new Mock<IUsersRepo>();
//            mockRepo.Setup(x => x.AddAsync(newUser));

//            var signInManager = new FakeSignInManager();
//            var mockAuth = Mock.Of<AuthDbContext>();

//            ILogger<UsersController> logger = Mock.Of<ILogger<UsersController>>();
//            var sut = new UsersController(mockRepo.Object,
//                signInManager, mockAuth, logger);



//        }
//        var sut = new CharacterController(mockRepo.Object, mapper);

//        IEnumerable<ApiCharacter> result = sut.Get();

//        var resultList = result.ToList();

//        Assert.Equal(characters.Count, resultList.Count);
//            for (var i = 0; i<resultList.Count; i++)
//            {
//                Assert.Equal(characters[i].Id, resultList[i].Id);
//                Assert.Equal(characters[i].Name, resultList[i].Name);
//            }
//}

//// https://stackoverflow.com/questions/48189741/mocking-a-signinmanager/54558958
//public class FakeSignInManager : SignInManager<IdentityUser>
//        {
//            public FakeSignInManager()
//                : base(new Mock<FakeUserManager>().Object,
//                      new HttpContextAccessor(),
//                      new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
//                      new Mock<IOptions<IdentityOptions>>().Object,
//                      new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
//                      new Mock<IAuthenticationSchemeProvider>().Object)
//            { }
//        }

//        public class FakeUserManager : UserManager<IdentityUser>
//        {
//            public FakeUserManager()
//                : base(new Mock<IUserStore<IdentityUser>>().Object,
//                      new Mock<IOptions<IdentityOptions>>().Object,
//                      new Mock<IPasswordHasher<IdentityUser>>().Object,
//                      new IUserValidator<IdentityUser>[0],
//                      new IPasswordValidator<IdentityUser>[0],
//                      new Mock<ILookupNormalizer>().Object,
//                      new Mock<IdentityErrorDescriber>().Object,
//                      new Mock<IServiceProvider>().Object,
//                      new Mock<ILogger<UserManager<IdentityUser>>>().Object)
//            { }

//        }
//    }
}

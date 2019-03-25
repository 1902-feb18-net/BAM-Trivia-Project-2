using BAMTriviaProject2.DAL;
using BAMTriviaProject2.WebAPI.Controllers;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BAMTriviaProject2.Testing
{
    public class QuestionsRepoTest
    {
        //[Fact]
        //public void AddQuestion()
        //{
        //    QuestionsModel newQuestion = new QuestionsModel
        //    {
        //        Category = "Movie",
        //        Type = "Fill",
        //        Rating = 1,
        //        Qstring = "What was the snowman in the movie Frozen called?"
        //    };

        //    var mockRepo = new Mock<IQuestionRepo>();
        //    mockRepo.Setup(x => x.AddQuestion(newQuestion));

        //    ILogger<QuestionsController> logger = Mock.Of<ILogger<QuestionsController>>();
        //    var sut = new QuestionsController(mockRepo.Object, logger);

        //    IEnumerable<QuestionsModel> result = sut.Get();
        //    var resultList = result.ToString();
        //}

    }
}

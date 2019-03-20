using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL
{
    public class Mapper
    {
        //public static Orders Map(OrderImp Order) => new Orders
        //{
        //    OrderId = Order.OrderID,
        //    OrderDate = Order.OrderDate,
        //    OrderCustomerId = Order.OrderCustomer,
        //    OrderCost = Order.TotalOrderCost(),
        //    OrderStoreId = Order.StoreId
        //};

        //public static OrderImp Map(Orders Order) => new OrderImp
        //{
        //    OrderID = Order.OrderId,
        //    OrderDate = Order.OrderDate,
        //    OrderCustomer = Order.OrderCustomerId,
        //    OrderCost = Order.OrderCost,
        //    StoreId = Order.OrderStoreId,

        //    GamesInOrder = Map(Order.OrderGames).ToList(),
        //};

        public static Answers Map(AnswerModel answers) => new Answers
        {
            Aid = answers.Id,
            Qid = answers.QuestionId,
            Correct = answers.Correct,
            Aanswer = answers.Answer
        };

        public static AnswerModel Map(Answers answers) => new AnswerModel
        {
            Id = answers.Aid,
            QuestionId = answers.Qid,
            Correct = answers.Correct,
            Answer = answers.Aanswer
        };

        public static Questions Map(QuestionsModel questions) => new Questions
        {
            Qid = questions.Id,
            Qcategory = questions.Category,
            QaverageReview = questions.AverageReview,
            Qrating = questions.Rating,
            Qtype = questions.Type,
        };

        public static QuestionsModel Map(Questions questions) => new QuestionsModel
        {
            Id = questions.Qid,
            Category = questions.Qcategory,
            AverageReview = questions.QaverageReview,
            Rating = questions.Qrating,
            Type = questions.Qtype
        };

        public static Quiz Map(QuizesModel quizes) => new Quiz
        {
            QuizId = quizes.Id,
            QuizDifficulty = quizes.Difficulty,
            QuizMaxScore = quizes.MaxScore
        };

        public static QuizesModel Map(Quiz quizes) => new QuizesModel
        {
            Id = quizes.QuizId,
            Difficulty = quizes.QuizDifficulty,
            MaxScore = quizes.QuizMaxScore
        };

        public static QuizResults Map(QuizResultsModel results) => new QuizResults
        {
            QuizId = results.QuizId,
            Qid = results.Qid,
            Correct = results.Correct
        };

        public static QuizResultsModel Map(QuizResults results) => new QuizResultsModel
        {
            QuizId = results.QuizId,
            Qid = results.Qid,
            Correct = results.Correct
        };

        public static Reviews Map(ReviewsModel answers) => new Reviews
        {

        };

        public static ReviewsModel Map(Reviews answers) => new ReviewsModel
        {

        };

        public static Tusers Map(UsersModel answers) => new Tusers
        {

        };

        public static UsersModel Map(Tusers answers) => new UsersModel
        {

        };

        public static UserQuizzes Map(UserQuizesModel answers) => new UserQuizzes
        {

        };

        public static UserQuizesModel Map(UserQuizzes answers) => new UserQuizesModel
        {

        };
    }
}

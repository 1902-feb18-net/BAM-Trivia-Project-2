using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAMTriviaProject2.DAL
{
    public class Mapper : IMapper
    {

        public Answers Map(AnswerModel answers) => new Answers
        {
            Aid = answers.Id,
            Qid = answers.QuestionId,
            Correct = answers.Correct,
            Aanswer = answers.Answer
        };

        public AnswerModel Map(Answers answers) => new AnswerModel
        {
            Id = answers.Aid,
            QuestionId = answers.Qid,
            Correct = answers.Correct,
            Answer = answers.Aanswer
        };

        public Questions Map(QuestionsModel questions) => new Questions
        {
            Qid = questions.Id,
            Qcategory = questions.Category,
            QaverageReview = questions.AverageReview,
            Qrating = questions.Rating,
            Qtype = questions.Type,
            Qstring = questions.Qstring
        };

        public QuestionsModel Map(Questions questions) => new QuestionsModel
        {
            Id = questions.Qid,
            Category = questions.Qcategory,
            AverageReview = questions.QaverageReview,
            Rating = questions.Qrating,
            Type = questions.Qtype,
            Qstring = questions.Qstring
        };

        public Quiz Map(QuizzesModel quizes) => new Quiz
        {
            QuizId = quizes.Id,
            QuizDifficulty = quizes.Difficulty,
            QuizMaxScore = quizes.MaxScore
        };

        public QuizzesModel Map(Quiz quizes) => new QuizzesModel
        {
            Id = quizes.QuizId,
            Difficulty = quizes.QuizDifficulty,
            MaxScore = quizes.QuizMaxScore
        };

        public QuizQuestions Map(QuizQuestionsModel qq) => new QuizQuestions
        {
            QuizId = qq.QuizId,
            Qid = qq.Qid,
        };

        public QuizQuestionsModel Map(QuizQuestions qq) => new QuizQuestionsModel
        {
            QuizId = qq.QuizId,
            Qid = qq.Qid,
        };

        public Results Map(ResultsModel results) => new Results
        {
            ResultId = results.ResultId,
            UserQuizId = results.UserQuizId,
            Qid = results.Qid,
            Correct = results.Correct,
            UserAnswer = results.UserAnswer
        };

        public ResultsModel Map(Results results) => new ResultsModel
        {
            ResultId = results.ResultId,
            UserQuizId = results.UserQuizId,
            Qid = results.Qid,
            Correct = results.Correct,
            UserAnswer = results.UserAnswer
        };

        public Reviews Map(ReviewsModel reviews) => new Reviews
        {
            Rid = reviews.Id,
            Qid = reviews.Qid,
            QuizId = reviews.QuizId,
            UserId = reviews.UserId,
            Rratings = reviews.Ratings
        };

        public ReviewsModel Map(Reviews reviews) => new ReviewsModel
        {
            Id = reviews.Rid,
            Qid = reviews.Qid,
            QuizId = reviews.QuizId,
            UserId = reviews.UserId,
            Ratings = reviews.Rratings
        };

        public Tusers Map(UsersModel users) => new Tusers
        {
            UserId = users.UserId,
            FirstName = users.FirstName,
            LastName = users.LastName,
            Username = users.Username,
            Pw = users.PW,
            CreditCardNumber = users.CreditCardNumber,
            PointTotal = users.PointTotal,
            AccountType = users.AccountType

        };

        public UsersModel Map(Tusers users) => new UsersModel
        {
            UserId = users.UserId,
            FirstName = users.FirstName,
            LastName = users.LastName,
            Username = users.Username,
            PW = users.Pw,
            CreditCardNumber = users.CreditCardNumber,
            PointTotal = users.PointTotal,
            AccountType = users.AccountType
        };

        public UserQuizzes Map(UserQuizzesModel quizes) => new UserQuizzes
        {
            UserId = quizes.UserId,
            QuizId = quizes.QuizId,
            QuizMaxScore = quizes.QuizMaxScore,
            QuizDate = quizes.QuizDate,
            QuizActualScore = quizes.QuizActualScore
        };

        public UserQuizzesModel Map(UserQuizzes quizes) => new UserQuizzesModel
        {
            UserId = quizes.UserId,
            QuizId = quizes.QuizId,
            QuizMaxScore = quizes.QuizMaxScore,
            QuizDate = quizes.QuizDate,
            QuizActualScore = quizes.QuizActualScore
        };

        public IEnumerable<Answers> Map(IEnumerable<AnswerModel> Answer) => Answer.Select(Map);

        public IEnumerable<AnswerModel> Map(IEnumerable<Answers> Answer) => Answer.Select(Map);

        public IEnumerable<Questions> Map(IEnumerable<QuestionsModel> Question) => Question.Select(Map);

        public IEnumerable<QuestionsModel> Map(IEnumerable<Questions> Question) => Question.Select(Map);

        public IEnumerable<Quiz> Map(IEnumerable<QuizzesModel> _Quiz) => _Quiz.Select(Map);

        public IEnumerable<QuizzesModel> Map(IEnumerable<Quiz> _Quiz) => _Quiz.Select(Map);

        public IEnumerable<QuizQuestions> Map(IEnumerable<QuizQuestionsModel> qq) => qq.Select(Map);

        public IEnumerable<QuizQuestionsModel> Map(IEnumerable<QuizQuestions> qq) => qq.Select(Map);

        public IEnumerable<Results> Map(IEnumerable<ResultsModel> Result) => Result.Select(Map);

        public IEnumerable<ResultsModel> Map(IEnumerable<Results> Result) => Result.Select(Map);

        public IEnumerable<Reviews> Map(IEnumerable<ReviewsModel> Review) => Review.Select(Map);

        public IEnumerable<ReviewsModel> Map(IEnumerable<Reviews> Review) => Review.Select(Map);

        public IEnumerable<UserQuizzes> Map(IEnumerable<UserQuizzesModel> uQuiz) => uQuiz.Select(Map);

        public IEnumerable<UserQuizzesModel> Map(IEnumerable<UserQuizzes> uQuiz) => uQuiz.Select(Map);

        public IEnumerable<Tusers> Map(IEnumerable<UsersModel> User) => User.Select(Map);

        public IEnumerable<UsersModel> Map(IEnumerable<Tusers> User) => User.Select(Map);
    }
}

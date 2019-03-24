using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL
{
    public interface IMapper
    {
        Answers Map(AnswerModel answers);
        AnswerModel Map(Answers answers);
        Questions Map(QuestionsModel questions);
        QuestionsModel Map(Questions questions);
        Quiz Map(QuizzesModel quizes);
        QuizzesModel Map(Quiz quizes);
        QuizQuestions Map(QuizQuestionsModel qq);
        QuizQuestionsModel Map(QuizQuestions qq);
        Results Map(ResultsModel results);
        ResultsModel Map(Results results);
        Reviews Map(ReviewsModel reviews);
        ReviewsModel Map(Reviews reviews);
        Tusers Map(UsersModel users);
        UsersModel Map(Tusers users);
        UserQuizzes Map(UserQuizzesModel quizes);
        UserQuizzesModel Map(UserQuizzes quizes);
        IEnumerable<Answers> Map(IEnumerable<AnswerModel> Answer);
        IEnumerable<AnswerModel> Map(IEnumerable<Answers> Answer);
        IEnumerable<Questions> Map(IEnumerable<QuestionsModel> Question);
        IEnumerable<QuestionsModel> Map(IEnumerable<Questions> Question);
        IEnumerable<Quiz> Map(IEnumerable<QuizzesModel> _Quiz);
        IEnumerable<QuizzesModel> Map(IEnumerable<Quiz> _Quiz);
        IEnumerable<QuizQuestions> Map(IEnumerable<QuizQuestionsModel> qq);
        IEnumerable<QuizQuestionsModel> Map(IEnumerable<QuizQuestions> qq);
        IEnumerable<Results> Map(IEnumerable<ResultsModel> Result);
        IEnumerable<ResultsModel> Map(IEnumerable<Results> Result);
        IEnumerable<Reviews> Map(IEnumerable<ReviewsModel> Review);
        IEnumerable<ReviewsModel> Map(IEnumerable<Reviews> Review);
        IEnumerable<UserQuizzes> Map(IEnumerable<UserQuizzesModel> uQuiz);
        IEnumerable<UserQuizzesModel> Map(IEnumerable<UserQuizzes> uQuiz);
        IEnumerable<Tusers> Map(IEnumerable<UsersModel> User);
        IEnumerable<UsersModel> Map(IEnumerable<Tusers> User);
    }
}

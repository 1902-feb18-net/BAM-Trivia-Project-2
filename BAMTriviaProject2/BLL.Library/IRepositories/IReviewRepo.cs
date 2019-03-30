using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IReviewRepo
    {
        List<ReviewsModel> GetReviewsByQuizId(int quizId);

        List<ReviewsModel> GetReviewsByQuestionId(int questionId);

        List<ReviewsModel> GetReviewsByUserId(int userId);

        IEnumerable<ReviewsModel> GetAllReviews();

        void DeleteReview(int Id);
    }
}

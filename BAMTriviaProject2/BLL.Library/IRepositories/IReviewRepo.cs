using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IReviewRepo
    {
        ReviewsModel GetByReviewId(int reviewId);

        List<ReviewsModel> GetReviewsByQuizId(int quizId);

        List<ReviewsModel> GetReviewsByQuestionId(int questionId);

        List<ReviewsModel> GetReviewsByUserId(int userId);

        IEnumerable<ReviewsModel> GetAllReviews();

        Task<int> AddReview(ReviewsModel review);
        Task<int> DeleteReviewAsync(int Id);
        Task<int> Save();
    }
}

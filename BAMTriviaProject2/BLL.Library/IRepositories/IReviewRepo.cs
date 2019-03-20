using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IReviewRepo
    {
        List<ReviewsModel> GetReviewsByQuizId(int QId);

        List<ReviewsModel> GetReviewsByQuestionId(int questionId);

        List<ReviewsModel> GetReviewsByUser(int userId);
    }
}

using BLL.Library.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Library.Models;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        public List<ReviewsModel> GetReviewsByQuizId(int QId)
        {
            List<ReviewsModel> list = new List<ReviewsModel>();
            return list;
        }

        public List<ReviewsModel> GetReviewsByQuestionId(int questionId)
        {
            List<ReviewsModel> list = new List<ReviewsModel>();
            return list;
        }

        public List<ReviewsModel> GetReviewsByUser(int userId)
        {
            List<ReviewsModel> list = new List<ReviewsModel>();
            return list;
        }
    }
}

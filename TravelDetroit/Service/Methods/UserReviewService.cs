using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.DAL;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Methods
{
    public class UserReviewService
    {
        public void SaveReview(string reviewText, int locationId, int userId)
        {
            new UserReviewRepository().Create(reviewText, locationId, userId);
        }

        public UserReview ReadSingle(int userId, int locationId)
        {
            return AutoMapper.Mapper.Map<UserReview>(new UserReviewRepository().ReadSingle(userId, locationId));
        }

        public List<UserReview> GetReviewsByLocation(int locationId)
        {
            return AutoMapper.Mapper.Map<List<UserReview>>(new UserReviewRepository().GetReviewsByLocation(locationId));
        }

        public List<UserReview> GetReviewsByUserProfile(int userId)
        {
            return AutoMapper.Mapper.Map<List<UserReview>>(new UserReviewRepository().GetReviewsByUserProfile(userId));
        }

        public void DeleteReview(int userId, int locationId)
        {
            var repository = new UserReviewRepository();
            var record = repository.ReadSingle(userId, locationId);
            repository.DeleteReview(record);
        }
    }
}
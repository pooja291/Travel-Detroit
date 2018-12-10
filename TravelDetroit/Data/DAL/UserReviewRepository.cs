using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.Models;
using Microsoft.AspNet.Identity;

namespace TravelDetroit.Data.DAL
{
    public class UserReviewRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public void Create(string reviewText, int locationId, int userId)
        {
            var userReview = new UserReview()
            {
                UserProfile = _context.UserProfiles.Find(userId),
                Location = _context.Locations.Find(locationId),
                Review = reviewText
            };
            _context.SaveChanges();
        }

        public UserReview Read(int id)
        {
            return _context.UserReviews.SingleOrDefault(l => l.Id == id);
        }
        
        public UserReview ReadSingle(int userId, int locationId)
        {
            var userReview = _context.UserReviews.SingleOrDefault(r => r.UserProfile.Id == userId && r.Location.Id == locationId);
            return userReview;
        }

        public List<UserReview> GetReviewsByLocation(int locationId)
        {
            return _context.UserReviews.Where(r => r.Location.Id == locationId).ToList();
        }

        public List<UserReview> GetReviewsByUserProfile(int userId)
        {
            return _context.UserReviews.Where(r => r.UserProfile.Id == userId).ToList();
        }

        public void DeleteReview(UserReview record)
        {
            record.Review = null;
            _context.SaveChanges();
        }
    }
}
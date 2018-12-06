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

        public void SaveReview(Location location,UserReview userReviewInputfromForm)
        {
            var userReviewForModel = new UserReview();
            var userProfile = new UserProfile();
          
            _context.Locations.Add(location);
            userReviewForModel.Reviews = userReviewInputfromForm.Reviews;
            userProfile = HttpContext.Current.User.Identity.GetUserId() ;
            userReviewForModel.UserProfile = userProfile.Id;
            _context.UserReviews.Add(userReviewForModel);
            _context.SaveChanges();
            userReviewForModel.Location = location.Id;
            _context.SaveChanges();
                                   
        }
               
        public UserReview  Read(int id)
        {
            return _context.UserReviews.SingleOrDefault(l => l.Id == id);
        }


    }
}
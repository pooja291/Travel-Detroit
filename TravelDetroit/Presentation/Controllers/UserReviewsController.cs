using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using TravelDetroit.Presentation.ViewModels;
using TravelDetroit.Service.Methods;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Presentation.Controllers
{
    public class UserReviewsController
    {
        private LocationService _locationService = new LocationService();
        private UserProfileService _userProfileService = new UserProfileService();
        private UserReviewService _userReviewService = new UserReviewService();

        public UserReviewsController()
        {

        }

        [HttpPost]
        public EmptyResult SaveReview(Location locationId, UserReview userReviewInputfromForm)
        {
            _userReviewService.SaveReview(locationId,userReviewInputfromForm);
            return new EmptyResult();  
        }

                     
    }
}
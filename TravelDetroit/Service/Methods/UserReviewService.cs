using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.DAL;
using TravelDetroit.Service.Models;
using TravelDetroit.Service.Methods;

namespace TravelDetroit.Service.Methods
{
    public class UserReviewService
    {

        public void SaveReview(Location location, UserReview userReviewInputfromForm)
        {
            var saveReview = AutoMapper.Mapper.Map<Data.Models.UserReview>(userReviewInputfromForm);
            var saveLocation = AutoMapper.Mapper.Map<Data.Models.Location>(location);
        //    new UserReviewRepository().SaveReview(saveReview);
            new LocationRepository().SaveLocation(saveLocation);
            userReviewInputfromForm.Reviews = saveReview.Reviews;
            location.Id = saveLocation.Id;
        }
           
    }
}
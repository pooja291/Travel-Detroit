using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Presentation.ViewModels
{
    public class LocationIndexViewModel
    {
        public Location Location { get; set; }
        public List<UserReview> UserReviews { get; set; }
    }
}
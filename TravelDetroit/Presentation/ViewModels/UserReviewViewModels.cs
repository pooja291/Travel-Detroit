using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Presentation.ViewModels;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Presentation.ViewModels
{
    public class UserReviewIndexViewModel
    {
        public int Id { get; set; }
        public string Reviews { get; set; }
            
        public UserProfile UserProfile { get; set; }
        public Location Location { get; set; }
    }
}
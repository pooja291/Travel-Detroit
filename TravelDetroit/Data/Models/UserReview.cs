using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TravelDetroit.Data.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public UserProfile UserProfile { get; set; }
        public Location Location { get; set; }
    }
}
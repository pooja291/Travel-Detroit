using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelDetroit.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public Dictionary<int, string> FavoriteLocations { get; set; }
    }
}
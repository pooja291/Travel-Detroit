using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
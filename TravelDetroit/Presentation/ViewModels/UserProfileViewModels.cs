using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Presentation.ViewModels
{
    public class UserProfileIndexViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }
        public List<UserProfile> SearchUsersResults { get; set; }
        public List<Location> SearchLocationResults { get; set; }
    }

    public class UserProfileUserViewModel
    {
        public UserProfile UserProfile { get; set; }
    }
}
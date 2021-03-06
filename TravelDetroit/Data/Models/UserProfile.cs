﻿using System.Collections.Generic;
using TravelDetroit.Data.DAL;

namespace TravelDetroit.Data.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Location> Locations { get; set; }
    }

    public class SearchUsersViewModel
    {
        public List<UserProfile> Users { get; set; }
    }
}
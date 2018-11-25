using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Models;
using Microsoft.AspNet.Identity;

namespace TravelDetroit.HelperMethods
{
    public class HelperMethods
    {
        public static UserProfile GetUserProfileByName(string userName)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            return _context.UserProfiles.Single(u => u.ApplicationUser.UserName == userName);
        }
    }
}
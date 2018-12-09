using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.Models;

namespace TravelDetroit.Data.DAL
{
    public class UserProfileRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public void Create(ApplicationUser applicationUser, string name)
        {
            _context.UserProfiles.Add(new UserProfile
            {
                ApplicationUser = applicationUser,
                Name = name,
                Locations = null
            });
            _context.SaveChanges();
        }

        public UserProfile Read(int id)
        {
            return _context.UserProfiles.Include(x => x.Locations).Single(u => u.Id == id);
        }

        public UserProfile Read(string id)
        {
            return _context.UserProfiles.SingleOrDefault(u => u.ApplicationUser.Id == id);
        }

        public List<UserProfile> SearchByName(string name)
        {
            return _context.UserProfiles.Where(u => u.Name.Contains(name)).ToList();
        }

        public UserProfile GetCurrentUserProfile()
        {
            var currentApplicationUserId = HttpContext.Current.User.Identity.GetUserId();
            if (currentApplicationUserId != null)
                return _context.UserProfiles.Include("Locations").Single(u => u.ApplicationUser.Id == currentApplicationUserId);
            return new UserProfile();
        }

        public void Update(int id, string name, ICollection<Location> locations)
        {
            var userProfile = _context.UserProfiles.SingleOrDefault(u => u.Id == id);
            userProfile.Name = name;
            userProfile.Locations = locations;
            _context.SaveChanges();
        }

        public void Delete(UserProfile userProfile)
        {
            _context.UserProfiles.Remove(userProfile);
            _context.SaveChanges();
        }
    }
}
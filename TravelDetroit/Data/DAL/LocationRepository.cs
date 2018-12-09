using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.Models;

namespace TravelDetroit.Data.DAL
{
    public class LocationRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public void SaveLocation(Location location)
        {
            if (_context.Locations.Where(l => l.PlaceId == location.PlaceId).Count() == 0)
            {
                _context.Locations.Add(location);
                _context.SaveChanges();
            }
        }

        public void SaveLocationToUser(int userId, string locationPlaceId)
        {
            var user = _context.UserProfiles.Find(userId);
            var location = _context.Locations.FirstOrDefault(l => l.PlaceId == locationPlaceId);
            if (user.Locations == null)
            {
                user.Locations = new List<Location>();
            }
            if (user.Locations.Where(l => l.PlaceId == location.PlaceId).Count() == 0)
            {
                user.Locations.Add(location);
                _context.SaveChanges();
            }
        }

        public Location Read(int id)
        {
            return _context.Locations.SingleOrDefault(l => l.Id == id);
        }

        public Location FindByPlaceId(string placeId)
        {
            return _context.Locations.SingleOrDefault(l => l.PlaceId == placeId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Data.DAL;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Methods
{
    public class LocationService
    {
        public void SaveLocationToTable(Location location)
        {
            var saveLocation = AutoMapper.Mapper.Map<Data.Models.Location>(location);
            new LocationRepository().SaveLocation(saveLocation);
            location.Id = saveLocation.Id;
        }

        public void SaveLocationToUser(int userId, string locationPlaceId)
        {
            new LocationRepository().SaveLocationToUser(userId, locationPlaceId);
        }

        public Location FindByPlaceId(string placeId)
        {
            return AutoMapper.Mapper.Map<Location>(new LocationRepository().FindByPlaceId(placeId));
        }

        public void SaveLocation(Location location, UserProfile userProfile)
        {
            if (new LocationRepository().FindByPlaceId(location.PlaceId) == null)
            {
                SaveLocationToTable(location);
            }
            if (userProfile.Locations.Where(l => l.PlaceId == location.PlaceId).Count() == 0)
            {
                SaveLocationToUser(userProfile.Id, location.PlaceId);
            }
        }
    }
}
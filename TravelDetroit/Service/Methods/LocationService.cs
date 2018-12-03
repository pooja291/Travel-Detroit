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
        public void SaveLocation(Location location)
        {
            var saveLocation = AutoMapper.Mapper.Map<Data.Models.Location>(location);
            new LocationRepository().SaveLocation(saveLocation);
            location.Id = saveLocation.Id;
        }

        public void SaveLocationToUser(int userId, int locationId)
        {
            new LocationRepository().SaveLocationToUser(userId, locationId);
        }
    }
}
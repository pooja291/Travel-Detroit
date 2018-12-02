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
        }

        public void SaveLocationToUser(int userId, string locationPlaceId)
        {
            new LocationRepository().SaveLocationToUser(userId, locationPlaceId);
        }
    }
}
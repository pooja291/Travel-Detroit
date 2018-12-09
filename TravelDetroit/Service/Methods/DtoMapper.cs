using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Methods
{
    public class DtoMapper
    {
        public Location Map(GooglePlacesLocationDTO dto)
        {
            string tags = "";
            foreach (string item in dto.result.types)
            {
                tags += item + ", ";
            }

            return new Location()
            {
                Name = dto.result.name,
                Address = dto.result.formatted_address,
                PlaceId = dto.result.place_id,
                Tags = tags.Substring(0, tags.Count() - 2),
                UserProfiles = new List<UserProfile>()
            };
        }
    }
}
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
            return new Location()
            {
                Name = dto.result.name,
                Address = dto.result.formatted_address,
                PlaceId = dto.result.place_id,
                Tags = dto.result.types.ToString()
            };
        }
    }
}
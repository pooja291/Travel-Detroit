using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TravelDetroit.Service.Models
{
    public class GooglePlacesLocationDTO
    {
        public PlacesResultDto result { get; set; }
    }
}
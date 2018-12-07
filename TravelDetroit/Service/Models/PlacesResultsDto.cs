using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDetroit.Service.Models
{
    public class PlacesResultDto
    {
        public string name { get; set; }
        public string formatted_address { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }
}
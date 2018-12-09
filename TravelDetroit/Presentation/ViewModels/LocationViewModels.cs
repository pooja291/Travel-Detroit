using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Presentation.ViewModels
{
    public class LocationsIndexViewModel
    {
        public bool IsLoggedIn { get; set; }
        public Location Location { get; set; }
    }

    public class LocationsSearchResultsViewModel
    {
        public string SearchText { get; set; }
        public List<Location> SearchLocationResults { get; set; }
    }
}
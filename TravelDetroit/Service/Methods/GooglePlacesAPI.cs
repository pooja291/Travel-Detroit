using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Methods
{
    public class GooglePlacesAPI
    {
        public string SearchLocations(string searchText)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(
                    "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
                    "location=42.3330,-83.0465" +
                    "&radius=20000" +
                    "&keyword=" + searchText +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4").Result;
            }
        }

        public string GetLocationDetails(string placeId)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(
                    "https://maps.googleapis.com/maps/api/place/details/json?" +
                    "placeid=" + placeId +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4").Result;
            }
        }
    }
}
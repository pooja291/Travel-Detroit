using System.Net.Http;
using System.Web.Mvc;
using TravelDetroit.Service.Methods;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Controllers
{
    public class LocationsController : Controller
    {

        private LocationService _locationService = new LocationService();
        private UserProfileService _userProfileService = new UserProfileService();

        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

        // GET: Locations/SearchLocation
        [HttpGet()]
        public async System.Threading.Tasks.Task<ContentResult> SearchLocation(string searchText)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(
                    "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?" +
                    "input=" + searchText +
                    "&inputtype=textquery" +
                    "&fields=formatted_address,geometry,icon,id,name,permanently_closed,photo,place_id,type" +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4" +
                    "&locationbias=circle:20000@42.3330,-83.0465");
                return Content(response);
            }
        }

        // GET: Locations/SearchLocations
        [HttpGet()]
        public async System.Threading.Tasks.Task<ContentResult> SearchLocations(string searchText)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(
                    "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
                    "location=42.3330,-83.0465" +
                    "&radius=2000" +
                    "&keyword="+ searchText +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4");
                return Content(response);
            }
        }

        [HttpPost]
        public ContentResult SaveLocation(Location location)
        {
            _locationService.SaveLocation(location);
            return Content(location.Id.ToString());
        }

        [HttpPost]
        public EmptyResult SaveLocationToUser(int locationId)
        {
            var currentUser = _userProfileService.GetCurrentUserProfile();
            _locationService.SaveLocationToUser(currentUser.Id, locationId);
            return new EmptyResult();
        }
    }
}
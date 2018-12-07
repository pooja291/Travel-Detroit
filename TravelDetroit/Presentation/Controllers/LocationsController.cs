using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using TravelDetroit.Service.Methods;
using TravelDetroit.Service.Models;
using TravelDetroit.Presentation.ViewModels;

namespace TravelDetroit.Controllers
{
    public class LocationsController : Controller
    {

        private LocationService _locationService = new LocationService();
        private UserProfileService _userProfileService = new UserProfileService();

        // GET: Location/Index/

        public ActionResult Index(string placeId)
        {
            var model = new LocationsIndexViewModel();
            Location location = new LocationService().FindByPlaceId(placeId);
            if (location == null)
            {
                model.Location = GetLocationFromApi(placeId);
            }
            else
            {
                model.Location = location;
            }
            return View(model);
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
        public ActionResult SearchLocations(string searchText)
        {
            var result = new GooglePlacesAPI().SearchLocations(searchText);
            return Content(result);
        }

        [HttpGet()]
        public Location GetLocationFromApi(string placeId)
        {
            using (WebClient wc = new WebClient())
            {
                var json = new GooglePlacesAPI().GetLocationDetails(placeId);
                var locationToMap = JsonConvert.DeserializeObject<GooglePlacesLocationDTO>(json);
                return new DtoMapper().Map(locationToMap);
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
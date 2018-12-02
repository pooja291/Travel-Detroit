using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using TravelDetroit.Presentation.ViewModels;
using TravelDetroit.Service.Methods;
using System.Linq;

namespace TravelDetroit.Controllers
{
    public class UserProfilesController : Controller
    {

        private UserProfileService _userProfileService = new UserProfileService();
        private LocationService _locationService = new LocationService();

        public UserProfilesController()
        {
        }

        // GET: UserProfiles
        public ActionResult Index(string name)
        { 
            var currentUser = _userProfileService.GetCurrentUserProfile();
            var model = new UserProfileIndexViewModel()
            {
                Name = currentUser.Name,
                Locations = currentUser.Locations,
                SearchUsersResults = _userProfileService.UserSearchByName(name)
            };
            return View(model);
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using TravelDetroit.Models;
using System.Linq;

namespace TravelDetroit.Controllers
{
    public class UserProfilesController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        public UserProfilesController()
        {
        }

        // GET: UserProfiles
        public ActionResult Index(int id)
        {
            var data = _context.UserProfiles.Include("Locations").FirstOrDefault(x => x.Id == id);
            return View(data);
        }

        public ActionResult AddLocationToUser(UserProfile userProfile)
        {
            return View("AddLocationToUser", userProfile);
        }
    }
}
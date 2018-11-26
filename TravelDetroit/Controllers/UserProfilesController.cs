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
        public ActionResult Index()
        {
            var user = new UserProfile();
            return View(user);
        }

        public ActionResult AddLocationToUser(int id)
        {
            return View("AddLocationToUser", id);
        }
    }
}
using System.Web.Mvc;
using TravelDetroit.Models;

namespace TravelDetroit.Controllers
{
    public class UserProfilesController : Controller
    {

        private ApplicationDbContext _context;

        public UserProfilesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: UserProfiles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddLocationToUser(int id)
        {
            return View("AddLocationToUser", id);
        }
    }
}
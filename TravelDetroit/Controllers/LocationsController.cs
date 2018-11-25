using System.Net.Http;
using System.Web.Mvc;
using TravelDetroit.Models;

namespace TravelDetroit.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

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

        [HttpPost]
        public EmptyResult SaveLocation(Location location)
        {
            var context = new ApplicationDbContext();
            context.Locations.Add(location);
            context.SaveChanges();
            return new EmptyResult();
        }
    }
}
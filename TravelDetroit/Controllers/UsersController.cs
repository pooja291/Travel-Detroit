using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace TravelDetroit.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddLocationToUser(int id)
        {
            return View("AddLocationToUser", id);
        }

        [HttpGet()]
        public async System.Threading.Tasks.Task<ContentResult> PlaceSearch(string searchText)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?" +
                    "input=" + searchText + "&inputtype=textquery&fields=formatted_address,geometry,icon,id,name,permanently_closed,photo,place_id,type" +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4&locationbias=circle:20000@42.3330,-83.0465");
                var result = JsonConvert.DeserializeObject(response);
                return Content(response);
            }
        }
    }
}
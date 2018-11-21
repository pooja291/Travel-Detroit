using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelDetroit.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public Dictionary<int, string> FavoriteLocations { get; set; }
    }
}
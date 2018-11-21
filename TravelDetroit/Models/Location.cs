using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelDetroit.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public Dictionary<int, string> FavoritedBy { get; set; }
    }
}
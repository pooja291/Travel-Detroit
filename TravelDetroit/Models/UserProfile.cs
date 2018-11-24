using System.Collections.Generic;

namespace TravelDetroit.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
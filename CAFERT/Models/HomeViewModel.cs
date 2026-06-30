using System.Collections.Generic;

namespace CAFERT.Models
{
    public class HomeViewModel
    {
        public List<MenuItem> FeaturedItems { get; set; } = new();
        public List<TeamMember> TeamMembers { get; set; } = new();
    }
}

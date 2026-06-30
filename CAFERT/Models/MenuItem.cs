using Microsoft.EntityFrameworkCore;

namespace CAFERT.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }
        public int SortOrder { get; set; }
    }
}

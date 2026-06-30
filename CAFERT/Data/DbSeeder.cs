using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CAFERT.Models;

namespace CAFERT.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Seed TeamMembers (Replace all to fix Tamara's photo and update paths)
            if (!await context.TeamMembers.AnyAsync() || await context.TeamMembers.AnyAsync(t => t.PhotoUrl.Contains("sites/10") || t.PhotoUrl.Contains("unsplash")))
            {
                // Clear old team data to re-create it clean
                context.TeamMembers.RemoveRange(context.TeamMembers);
                await context.SaveChangesAsync();

                var team = new[]
                {
                    new TeamMember
                    {
                        Name = "John Doe",
                        Role = "Head Chef",
                        PhotoUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/coffee-cafe-professional-steam-uniform-appliance-c-PMGJDPJ-1.jpg",
                        Bio = "John has over 15 years of culinary experience in Michelin-star restaurants, perfecting French and Italian cuisine.",
                        SortOrder = 1
                    },
                    new TeamMember
                    {
                        Name = "Marie Bell",
                        Role = "Cook",
                        PhotoUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/coffee-business-owner-concept-portrait-of-happy-at-7YYU92J-1-1.jpg",
                        Bio = "Passionate about locally-sourced fresh ingredients, Marie makes sure every plate is a visual and sensory masterpiece.",
                        SortOrder = 2
                    },
                    new TeamMember
                    {
                        Name = "Ray Stanley",
                        Role = "Barista",
                        PhotoUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/handsome-barista-smiling-at-camera-at-the-coffee-s-PX3TA4F-1-1.jpg",
                        Bio = "An award-winning latte artist, Ray has travelled across South America and Africa to select our specialty beans.",
                        SortOrder = 3
                    },
                    new TeamMember
                    {
                        Name = "Tamara Ramsey",
                        Role = "Baker",
                        PhotoUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/pretty-barista-smiling-at-camera-at-the-coffee-sho-PPS7RBN-1.jpg",
                        Bio = "Tamara starts her day at 4 AM every morning, crafting our signature sourdough, pastries, and artisanal breads.",
                        SortOrder = 4
                    },
                    new TeamMember
                    {
                        Name = "Jennie Hall",
                        Role = "General Manager",
                        PhotoUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/cafe-or-shop-employees-portrait-55RM3LL-1.jpg",
                        Bio = "Jennie ensures our operations run smoothly and greets every guest with a warm, welcoming smile.",
                        SortOrder = 5
                    }
                };
                context.TeamMembers.AddRange(team);
                await context.SaveChangesAsync();
            }

            // Seed MenuItems (Clear steak, ribeye, unsplash links to keep it strictly coffee, toasts, and sweets)
            if (!await context.MenuItems.AnyAsync() || await context.MenuItems.AnyAsync(m => m.Name.Contains("Steak") || m.ImageUrl.Contains("unsplash") || m.ImageUrl.Contains("sites/10")))
            {
                context.MenuItems.RemoveRange(context.MenuItems);
                await context.SaveChangesAsync();

                var menu = new[]
                {
                    // Breakfasts (Toasts or Sweets)
                    new MenuItem
                    {
                        Category = "Breakfasts",
                        Name = "Toast With Eggs",
                        Description = "Toasted sourdough bread topped with flax seeds, fresh herbs, house sauce, and poached eggs.",
                        Price = 12.50m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/breakfast-1.jpg",
                        IsFeatured = true,
                        SortOrder = 1
                    },
                    new MenuItem
                    {
                        Category = "Breakfasts",
                        Name = "Vegetarian Breakfast",
                        Description = "Artisan grain toast served with sunny side up eggs, fresh field greens, and sliced avocados.",
                        Price = 11.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/vegetarian-breakfast-.jpg",
                        IsFeatured = true,
                        SortOrder = 2
                    },
                    new MenuItem
                    {
                        Category = "Breakfasts",
                        Name = "Hummus Toast",
                        Description = "Crispy brioche spread with smooth beetroot hummus, topped with select spices and fresh lime.",
                        Price = 10.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/hummus-vegan-snack.jpg",
                        IsFeatured = false,
                        SortOrder = 3
                    },

                    // Sweets / Desserts
                    new MenuItem
                    {
                        Category = "Desserts",
                        Name = "Strawberry Pancakes",
                        Description = "Fluffy buttermilk pancakes stacked high, topped with fresh strawberries, honey, and fresh mint.",
                        Price = 9.50m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/09/dessert.jpg",
                        IsFeatured = false,
                        SortOrder = 1
                    },
                    new MenuItem
                    {
                        Category = "Desserts",
                        Name = "Cottage Cheese Pancakes",
                        Description = "Curd cheese fritters served with rich organic honey, sour cream, and mixed forest nuts.",
                        Price = 10.50m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/cottage-cheese-pancakes-with-tasty-honey-and-mixed-nuts-syrniki-curd-fritters-.jpg",
                        IsFeatured = false,
                        SortOrder = 2
                    },
                    new MenuItem
                    {
                        Category = "Desserts",
                        Name = "Panna Cotta",
                        Description = "Silky vanilla bean cream dessert topped with strawberry coulis and fresh mint leaves.",
                        Price = 8.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/panna-cotta-dessert-.jpg",
                        IsFeatured = true,
                        SortOrder = 3
                    },
                    new MenuItem
                    {
                        Category = "Desserts",
                        Name = "Chocolate Mousse",
                        Description = "Rich dark chocolate mousse layered with jelly and custom salted caramel drizzle.",
                        Price = 9.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/chocolate-mousse-dessert.jpg",
                        IsFeatured = false,
                        SortOrder = 4
                    },

                    // Drinks (Coffee Varieties)
                    new MenuItem
                    {
                        Category = "Drinks",
                        Name = "Classic Cappuccino",
                        Description = "Premium espresso shot layered with velvety microfoamed milk, prepared by our master barista.",
                        Price = 4.50m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/barista-making-classic-cappuccino.jpg",
                        IsFeatured = false,
                        SortOrder = 1
                    },
                    new MenuItem
                    {
                        Category = "Drinks",
                        Name = "Iced Espresso Tonic",
                        Description = "Chilled double shot of espresso combined with tonic water and fresh lemon peel over ice.",
                        Price = 5.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/iced-americano-or-espresso-tonic-coffee-cold-cocktail.jpg",
                        IsFeatured = false,
                        SortOrder = 2
                    },
                    new MenuItem
                    {
                        Category = "Drinks",
                        Name = "Strawberry Matcha Latte",
                        Description = "Uji matcha whisked with creamy whole milk and sweet strawberry puree over ice.",
                        Price = 5.50m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/strawberry-matcha-latte.jpg",
                        IsFeatured = false,
                        SortOrder = 3
                    },
                    new MenuItem
                    {
                        Category = "Drinks",
                        Name = "Iced Dalgona Coffee",
                        Description = "Whipped coffee foam spooned over sweet cold milk, a creamy coffee indulgence.",
                        Price = 5.00m,
                        ImageUrl = "https://cafert.templatekit.co/wp-content/uploads/2021/10/iced-frothy-dalgona-coffee.jpg",
                        IsFeatured = false,
                        SortOrder = 4
                    }
                };
                context.MenuItems.AddRange(menu);
                await context.SaveChangesAsync();
            }
        }
    }
}

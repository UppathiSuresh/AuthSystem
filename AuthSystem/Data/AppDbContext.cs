using DrinkAndGo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Drink>().HasData(

                new Drink
                {
                    DrinkId=1,
                    Name = "Beer",
                    Price = 7.95M,
                    ShortDescription = "The most widely consumed alcohol",
                    LongDescription = "Beer is the world's oldest[1][2][3] and most widely consumed[4] alcoholic drink; it is the third most popular drink overall, after water and tea.[5] The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.[6] Most beer is flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The fermentation process causes a natural carbonation effect, although this is often removed during processing, and replaced with forced carbonation.[7] Some of humanity's earliest known writings refer to the production and distribution of beer: the Code of Hammurabi included laws regulating beer and beer parlours.",
                    Category = CategoriesName["Alcoholic"],
                    ImageUrl = "http://imgh.us/beerL_2.jpg",
                    InStock = true,
                    IsPreferredDrink = true,
                    ImageThumbnailUrl = "http://imgh.us/beerS_1.jpeg"
                }
                );

            modelBuilder.Entity<Drink>().HasData(

                new Drink
                {
                    DrinkId=2,
                    Name = "Rum & Coke",
                    Price = 12.95M,
                    ShortDescription = "Cocktail made of cola, lime and rum.",
                    LongDescription = "The world's second most popular drink was born in a collision between the United States and Spain. It happened during the Spanish-American War at the turn of the century when Teddy Roosevelt, the Rough Riders, and Americans in large numbers arrived in Cuba. One afternoon, a group of off-duty soldiers from the U.S. Signal Corps were gathered in a bar in Old Havana. Fausto Rodriguez, a young messenger, later recalled that Captain Russell came in and ordered Bacardi (Gold) rum and Coca-Cola on ice with a wedge of lime. The captain drank the concoction with such pleasure that it sparked the interest of the soldiers around him. They had the bartender prepare a round of the captain's drink for them. The Bacardi rum and Coke was an instant hit. As it does to this day, the drink united the crowd in a spirit of fun and good fellowship. When they ordered another round, one soldier suggested that they toast ¡Por Cuba Libre! in celebration of the newly freed Cuba.",
                    Category = CategoriesName["Non-alcoholic"],
                    ImageUrl = "http://imgh.us/rumCokeL.jpg",
                    InStock = true,
                    IsPreferredDrink = false,
                    ImageThumbnailUrl = "http://imgh.us/rumAndCokeS.jpg"

                }

                );

            modelBuilder.Entity<Category>().HasData(new Category {CategoryId=1, CategoryName = "Alcoholic", Description = "All alcoholic drinks" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId=2, CategoryName = "Non-alcoholic", Description = "All non-alcoholic drinks" });

        }

        private static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> CategoriesName
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Alcoholic", Description="All alcoholic drinks" },
                        new Category { CategoryName = "Non-alcoholic", Description="All non-alcoholic drinks" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }


    }
}

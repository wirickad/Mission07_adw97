using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission06_adw97.Models
{
    //This is the database context class, when the database model is created, it comes here to insert the records below called 'seeding'
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seeding data
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action"
                }, 
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Romance"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Drama"
                }

            );

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Town",
                    Year = 2010,
                    Director = "Ben Affleck",
                    Rating = "R",
                    Edited = true,
                    LentTo = null,
                    Notes = null
                },

                new Movie
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                },

                new Movie
                {
                    MovieId = 3,
                    CategoryId = 2,
                    Title = "Hot Rod",
                    Year = 2007,
                    Director = "Akiva Schaffer",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                }
            );

        }
    }
}

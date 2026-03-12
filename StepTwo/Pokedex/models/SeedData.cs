using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Name = "Bulbasaur",
                    CatchDate = DateTime.Parse("2010-2-12"),
                    Type = "Grass",
                    DexNum = 0001,
                    Gender = "F"
                },

                new Movie
                {
                    Name = "Eevee",
                    CatchDate = DateTime.Parse("2013-12-5"),
                    Type = "Normal",
                    DexNum = 0133,
                    Gender = "M"
                },

                new Movie
                {
                    Name = "Noibat",
                    CatchDate = DateTime.Parse("2019-8-15"),
                    Type = "Dark",
                    DexNum = 0714,
                    Gender = "M"
                },

                new Movie
                {
                    Name = "Cosmog",
                    CatchDate = DateTime.Parse("2026-6-12"),
                    Type = "Psychic",
                    DexNum = 0789,
                    Gender = "F"
                }
            );
            context.SaveChanges();
        }
    }
}
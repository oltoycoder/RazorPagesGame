using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesGame.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesGameContext
                (serviceProvider.GetRequiredService<DbContextOptions<RazorPagesGameContext>>()))
            {
                //Look for any games 
                if (context.Game.Any())
                {
                    return; //DB has been seeded
                }

                context.Game.AddRange(new Game
                {
                Title = "Telltale's The Walking Dead Season 1",
                ReleaseDate = DateTime.Parse("2012-04-24"),
                Genre = "Point and click",
                NumberOfPlayableCharacters = 1,
                PlayableCharacterGender = "Male",
                PlayableCharacterRace = "Black"
                },

                new Game
                {
                    Title = "Life is Strange",
                    ReleaseDate = DateTime.Parse("2015-01-30"),
                    Genre = "Point and click",
                    NumberOfPlayableCharacters = 1,
                    PlayableCharacterGender = "Female",
                    PlayableCharacterRace = "White"
                },

                new Game
                {
                    Title = "The Last of Us",
                    ReleaseDate = DateTime.Parse("2013-06-14"),
                    Genre = "Third person shooter",
                    NumberOfPlayableCharacters = 2,
                    PlayableCharacterGender = "Male, Female", 
                    PlayableCharacterRace = "White"
                },

                new Game
                {
                    Title = "Marvel's Spider-Man",
                    ReleaseDate = DateTime.Parse("2018-09-07"),
                    Genre = "Action-adventure",
                    NumberOfPlayableCharacters = 3,
                    PlayableCharacterGender = "Male, Female",
                    PlayableCharacterRace = "White, Black"
                }
                
                );
                context.SaveChanges();
            }
        }
    }
}

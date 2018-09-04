using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Models;

namespace RazorPagesGame.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGame.Models.RazorPagesGameContext _context;

        public IndexModel(RazorPagesGame.Models.RazorPagesGameContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        public SelectList Genres { get; set; }
        public string GameGenre { get; set; }
        public SelectList Genders { get; set; }
        public string GameCharacterGender { get; set; }
        public SelectList Races { get; set; }
        public string GameCharacterRace { get; set; }

        public async Task OnGetAsync(string gameCharacterRace, string gameCharacterGender, string gameGenre, string searchString)
        {
            IQueryable<string> raceQuery = from g in _context.Game
                                           orderby g.PlayableCharacterRace
                                           select g.PlayableCharacterRace;

            IQueryable<string> genderQuery = from g in _context.Game
                                             orderby g.PlayableCharacterGender
                                             select g.PlayableCharacterGender;

            IQueryable<string> genreQuery = from g in _context.Game
                                            orderby g.Genre
                                            select g.Genre;

            var games = from g in _context.Game
                         select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(gameGenre))
            {
                games = games.Where(x => x.Genre == gameGenre);
            }

            if (!String.IsNullOrEmpty(gameCharacterGender))
            {
                games = games.Where(y => y.PlayableCharacterGender == gameCharacterGender);
            }

            if (!String.IsNullOrEmpty(gameCharacterRace))
            {
                games = games.Where(z => z.PlayableCharacterRace == gameCharacterRace);
            }

            Races = new SelectList(await raceQuery.Distinct().ToListAsync());
            Genders = new SelectList(await genderQuery.Distinct().ToListAsync());
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Game = await games.ToListAsync();
        }
    }
}

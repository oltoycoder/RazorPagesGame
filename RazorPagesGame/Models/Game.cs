using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesGame.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Number of playable characters")]
        public int NumberOfPlayableCharacters { get; set; }
        [Display(Name = "Playable character gender")]
        public string PlayableCharacterGender { get; set; }
        [Display(Name = "Playable character race")]
        public string PlayableCharacterRace { get; set; }
    }
}

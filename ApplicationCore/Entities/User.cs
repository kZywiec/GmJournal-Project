using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GmJournal.Data;


namespace GmJournal.Data.Entities
{
    public class User : EntityBase
    {
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        [Required]
        [Display(Name = "Login")]
        [StringLength(20, ErrorMessage = "Login Can't be longer than 20 character.")]
        public string login { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(16, ErrorMessage = "Password length must be between {2} and {1}.", MinimumLength = 5)]
        public string password { get; set; }

        [HiddenInput]
        public bool isAdmin { get; set; } = false;

        // --- Relationships ---
        [Required]
        public List<World> Worlds { get; set; } = new();
        
        [HiddenInput]
        public List<Character> Characters { get; set; } = new();

        public void AddWorld(World world)
            => Worlds.Add(world);

        public void AddCharacter(Character character)
            => Characters.Add(character);
    }
}
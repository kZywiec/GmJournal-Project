using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GmJournal.Data;
using GmJournal.Data.ViewModels;

namespace GmJournal.Data.Entities
{
    public class User : userModel
    {
        public User() : base() { }
        public User(userModel userModel)
        {
            this.login = userModel.login;
            this.password = userModel.password;
            this.isAdmin = userModel.isAdmin;
        }

        // --- Relationships ---
        public List<World> Worlds { get; set; } = new();
        public List<Character> Characters { get; set; } = new();

        public void AddWorld(World world)
            => Worlds.Add(world);

        public void AddCharacter(Character character)
            => Characters.Add(character);
    }
}
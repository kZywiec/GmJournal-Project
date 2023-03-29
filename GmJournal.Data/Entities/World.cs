using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GmJournal.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using GmJournal.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GmJournal.Data.Entities
{
    public class World : worldModel
    {

        public World() : base() { }
        public World(worldModel worldModel, ref User owner)
        {
            this.Owner = owner;
            this.Edit(worldModel);
            this.AddUser(owner);
            owner.AddWorld(this);
        }

        [Required]
        [HiddenInput]
        public User Owner { get; set; }

        [Required]
        [HiddenInput]
        public List<User> Users { get; set; } = new();

        [Required]
        [HiddenInput]
        public List<Character> Characters { get; set; } = new();

        public void SetOwner(User user)
        {
            this.Owner = user;
            AddUser(user);
        }

        public void AddUser(User user)
            => Users.Add(user);

        public void Edit(worldModel worldModel)
        {
            this.Name = worldModel.Name;
            this.Description = worldModel.Description;
            this.NextSessionDate = worldModel.NextSessionDate;
        }
    }
}

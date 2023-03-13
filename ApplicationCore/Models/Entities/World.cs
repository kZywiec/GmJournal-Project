using ApplicationCore.Models.EntitiesRelations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ApplicationCore.Models.Entities
{
    public class World : EntityBaseWithName
    {
        public World(string name, DateTime nextSessionDate, User user) : base(name)
        {
            this.nextSessionDate = nextSessionDate;
            this.Users_Worlds.Add(new User_World(user, this));
        }

        [Required]
        public string description { get; set; } = "";

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime nextSessionDate { get; set; }

        // --- Relationships ---
        [HiddenInput]
        public List<User_World> Users_Worlds { get; set; } = new();
    }
}

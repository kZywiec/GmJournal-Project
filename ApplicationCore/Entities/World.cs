using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VTT.Data;

namespace VTT.Data.Entities
{
    public class World : EntityBase
    {
        public World(string name, DateTime nextSessionDate, User creator)
        {
            this.Name = name;
            this.Owner = creator;
            this.NextSessionDate = nextSessionDate;
            this.Users.Add(this.Owner);
        }

        public World(string name,string description, DateTime nextSessionDate, User creator)
        {
            this.Name = name;
            this.Description = description;
            this.Owner = creator;
            this.NextSessionDate = nextSessionDate;
            this.Users.Add(this.Owner);
        }

        [StringLength(50)]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Enter date of next sesion")]

        [DataType(DataType.DateTime)]
        public DateTime NextSessionDate { get; set; }

        [Required]
        [HiddenInput]
        public User Owner { get; set; }

        [HiddenInput]
        public List<User> Users { get; set; } = new();

        [HiddenInput]
        public List<Character> Characters { get; set; } = new();
    }
}

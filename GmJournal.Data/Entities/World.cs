using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GmJournal.Data;

namespace GmJournal.Data.Entities
{
    public class World : EntityBase
    {

        public World()
        {
        }
        public World(string name, DateTime nextSessionDate)
        {
            this.Name = name;
            this.NextSessionDate = nextSessionDate;
            if (Owner != null)
                this.Users.Add(this.Owner);
            else
                throw new Exception("Owner not found");
        }

        public World(string name,string description, DateTime nextSessionDate)
        {
            this.Name = name;
            this.Description = description;
            this.NextSessionDate = nextSessionDate;
            if (Owner != null)
                this.Users.Add(this.Owner);
            else
                throw new Exception("Owner not found");
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

        [Required]
        [HiddenInput]
        public List<User> Users { get; set; } = new();

        [Required]
        [HiddenInput]
        public List<Character> Characters { get; set; } = new();
    }
}

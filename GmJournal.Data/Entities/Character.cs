using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using GmJournal.Data;
using Microsoft.AspNetCore.Mvc;
using GmJournal.Data.ViewModels;

namespace GmJournal.Data.Entities
{
    public class Character : characterModel
    {
        public Character():base()
        {

            this.CalculateStats();
        }

        public Character(characterModel characterModel,ref User owner,ref World world)
        {
            this.World = world;
            this.Owner = owner;

            this.Edit(characterModel);
            this.CalculateStats();

            world.Characters.Add(this);
            owner.Characters.Add(this);
        }
        //the user the character belongs to
        [Required]
        [HiddenInput]
        public User Owner { get; set; }

        //the world the character live in
        [Required] 
        [HiddenInput]
        public World World { get; set; }




        // Statistics

        //[Range(10, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int hp { get; set; }

        //[Range(6, 90, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int run { get; set; }

        //[Range(1, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int leap { get; set; }

        //[Range(20, 300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int stun { get; set; }

        //[Range(10, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int stamina { get; set; }

        //[Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int recovery { get; set; }

        //[Range(20, 300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        [HiddenInput]
        public int encumbrance { get; set; }


        [Required] 
        public List<Item> Items { get; set; } = new();

        public void CalculateStats()
        {
            hp = (body + will) / 2 * 5;
            stamina = (body + will) / 2 * 5;
            run = speed * 3;
            leap = speed * 3 / 6;
            recovery = (body + will) / 2;
            stun = (body + will) / 2 * 10;
            encumbrance = (body + will) / 2 * 10;
        }

        public void Edit(characterModel characterModel)
        {
            name = characterModel.name;
            sex = characterModel.sex;
            age = characterModel.age;
            race = characterModel.race;
            social_standing = characterModel.social_standing;
            homeland = characterModel.homeland;
            intelligence = characterModel.intelligence;
            reflex = characterModel.reflex;
            dexterity = characterModel.dexterity;
            body = characterModel.body;
            speed = characterModel.speed;
            empathy = characterModel.empathy;
            craft = characterModel.craft;
            will = characterModel.will;
            luck = characterModel.luck;
        }
    }

}
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Models.EntitiesRelations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApplicationCore.Models.Entities
{
    public class Character : EntityBaseWithName
    {
        public Character(string name, string sex, int age, string race, string social_standing, string homeland, int intelligence, int reflex, int dexterity, int body, int speed, int empathy, int craft, int will, int luck)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.race = race;
            this.social_standing = social_standing;
            this.homeland = homeland;
            this.intelligence = intelligence;
            this.reflex = reflex;
            this.dexterity = dexterity;
            this.body = body;
            this.speed = speed;
            this.empathy = empathy;
            this.craft = craft;
            this.will = will;
            this.luck = luck;
            this.CalculateStats();

            //User-worlds connection
        }


        // ---|*|ATTRIBIUTES|*|---

        //Basic informations
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string name { get; set; }

        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Sex is required")]
        public string sex { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required")]
        [Range(0, 150, ErrorMessage = "{0} must be between {1} and {2}")]
        public int age { get; set; }

        [Display(Name = "Race")]
        [Required(ErrorMessage = "Race is required")]
        [StringLength(20, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string race { get; set; }

        [Display(Name = "Social Standing")]
        [Required(ErrorMessage = "Social standing is required")]
        [StringLength(20, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string social_standing { get; set; }

        [Display(Name = "Homeland")]
        [Required(ErrorMessage = "Homeland is required")]
        public string homeland { get; set; }


        // Characteristics
        [Display(Name = "Intelligence")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int intelligence { get; set; }

        [Display(Name = "Reflexe")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int reflex { get; set; }

        [Display(Name = "Dexternity")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int dexterity { get; set; }

        [Display(Name = "Body")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int body { get; set; }

        [Display(Name = "Speed")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int speed { get; set; }

        [Display(Name = "Emphathy")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int empathy { get; set; }

        [Display(Name = "Craft")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int craft { get; set; }

        [Display(Name = "Will")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int will { get; set; }

        [Display(Name = "Luck")]
        [Required(ErrorMessage = "Please enter a value for {0}.")]
        [Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int luck { get; set; }

        // Statistics
        [Required]
        //[Range(10, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int hp { get; set; }

        [Required]
        //[Range(6, 90, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int run { get; set; }

        [Required]
        //[Range(1, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int leap { get; set; }

        [Required]
        //[Range(20, 300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int stun { get; set; }

        [Required]
        //[Range(10, 150, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int stamina { get; set; }

        [Required]
        //[Range(2, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int recovery { get; set; }

        [Required]
        //[Range(20, 300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int encumbrance { get; set; }

        // --- Relationships ---
        [Required]
        public int Users_Worlds_id { get; set; }

        [ForeignKey("Users_Worlds_id")]
        [ValidateNever]
        public User_World Users_Worlds { get; set; }

        [ValidateNever]
        public List<Character_Item> Items { get; set; } = new();



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
    }

}
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Models.EntitiesRelations;
using System.Web.Mvc;

namespace ApplicationCore.Models.Entities
{
    public class User : EntityBase
    {
        public User(string login, string password, bool isAdmin)
        {
            this.login = login;
            this.password = password;
            this.isAdmin = isAdmin;
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
        public bool isAdmin { get; set; }

        // --- Relationships ---
        [Required]
        public List<User_World> Users_Worlds_Characters { get; set; } = new();

    }
}
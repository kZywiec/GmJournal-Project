using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmJournal.Data.ViewModels
{
    public class userModel : EntityBase
    {
        public userModel() { }

        [Required]
        [Display(Name = "Login")]
        [StringLength(20, ErrorMessage = "Login length must be between {2} and {1}.", MinimumLength = 5)]
        public string login { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(16, ErrorMessage = "Password length must be between {2} and {1}.", MinimumLength = 5)]
        public string password { get; set; }

        [Required]
        [HiddenInput]
        public bool isAdmin { get; set; } = false;
    }
}

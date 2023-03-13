using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Entities
{
    public class Item_Type : EntityBaseWithName
    {
        public Item_Type(string name) : base(name)
        {
            this.items = new List<Item>();
        }

        [Required]
        public List<Item> items { get; set; }
    }
}
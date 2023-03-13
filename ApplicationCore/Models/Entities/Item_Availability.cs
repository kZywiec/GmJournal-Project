using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Entities
{
    public class Item_Availability : EntityBaseWithName
    {
        public Item_Availability(string name) : base(name)
        {
            this.items = new List<Item>();
        }

        [ValidateNever]
        public List<Item> items { get; set; }
    }
}
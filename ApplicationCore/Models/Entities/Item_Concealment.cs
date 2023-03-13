using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Models;

namespace ApplicationCore.Models.Entities
{
    public class Item_Concealment : EntityBaseWithName
    {
        public Item_Concealment(string name) : base(name)
        {
            this.items = new List<Item>();
        }

        [ValidateNever]
        public List<Item> items { get; set; }
    }
}
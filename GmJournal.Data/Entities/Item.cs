using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using GmJournal.Data;
using Microsoft.AspNetCore.Mvc;
using GmJournal.Data.ViewModels;

namespace GmJournal.Data.Entities
{
    public class Item : itemModel
    {

        public Item() : base()
        {
        }

        public Item(itemModel itemModel, ref User owner)
        {

        }

        //the character the item belongs to
        [Required]
        public Character Owner { get; set; }

        public void Edit(itemModel itemModel)
        {
            name = itemModel.name;
            quantity = itemModel.quantity;
            weight = itemModel.weight;
            cost = itemModel.cost;
            description = itemModel.description;
            type = itemModel.type;
            availability = itemModel.availability;
            concealment = itemModel.concealment;
        }
    }
}
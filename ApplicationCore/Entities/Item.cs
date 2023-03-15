using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using VTT.Data;

namespace VTT.Data.Entities
{
    public class Item : EntityBase
    {
        public Item(
            Character owner, string name, int quantity, 
            float weight, int cost, string description, 
            Item_Type type, Item_Availability availability, 
            Item_Concealment concealment)
        {
            Owner = owner;
            Name = name;
            this.quantity = quantity;
            this.weight = weight;
            this.cost = cost;
            this.description = description;
            Type = type;
            Availability = availability;
            this.concealment = concealment;
        }

        //the character the item belongs to
        public Character Owner { get; set; }

        [StringLength(50)]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        ///<summary> 
        ///Describes how many items character chawe in inventory. 
        ///</summary>
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int quantity { get; set; }

        ///<summary> 
        ///Describes how much the holder of this item will be additionary burdened. 
        ///</summary>
        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight is required.")]
        public float weight { get; set; }

        ///<summary> 
        ///Value of item in in-game money. 
        ///</summary>
        [Display(Name = "Cost")]
        [Required(ErrorMessage = "Cost is required.")]
        public int cost { get; set; }

        ///<summary> 
        ///It stores a description of the appearance, use or history of the item. 
        ///</summary>
        [Display(Name = "Description")]
        //[Required(ErrorMessage = "Description is required.")] !!!
        public string description { get; set; } = "";

        ///<summary> 
        ///Helps to manage items. 
        ///</summary>
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required.")]

        public Item_Type Type { get; set; }

        ///<summary> 
        ///Availability describes how easy it is to find a item in shops or how often should be encountered in combat. 
        ///</summary>
        [Display(Name = "Availability")]
        [Required(ErrorMessage = "Availability is required.")]
        public Item_Availability Availability { get; set; }

        ///<summary> 
        ///Concealment describes where you can hide a item. 
        ///</summary>
        [Display(Name = "Concealment")]
        [Required(ErrorMessage = "Concealment is required.")]
        public Item_Concealment concealment { get; set; }
    }
    public enum Item_Type
    {
        Armor,
        Clothing,
        Component,
        Container,
        Consumable,
        General,
        Mount,
        Tool_Kit,
        Weapon
    }

    public enum Item_Availability
    {
        Everywhere,
        Common,
        Poor,
        Rare
    }

    public enum Item_Concealment
    {
        Tiny,
        Small,
        Large,
        Cant_Hide
    }
}
using ApplicationCore.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.EntitiesRelations
{
    public class Character_Item : EntityBase
    {
        public Character_Item(Character character, Item item)
        {
            this.character = character;
            this.item = item;
            this.character_id = character.Id;
            this.item_id = item.Id; 
        }

        public int character_id { get; set; }
        [ForeignKey("character_id")]
        public Character character { get; set; }

        public int item_id { get; set; }
        [ForeignKey("item_id")]
        public Item item { get; set; }
    }
}
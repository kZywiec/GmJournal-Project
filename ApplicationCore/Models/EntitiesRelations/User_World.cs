using ApplicationCore.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.EntitiesRelations
{
    public class User_World : EntityBase
    {
        public User_World(User user, World world)
        {
            this.user = user;
            this.world = world;
            this.user_id = user.Id;
            this.world_id = world.Id;
        }

        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }

        public int world_id { get; set; }
        [ForeignKey("world_id")]
        public World world { get; set; }

        [Required]
        public List<Character> Characters { get; set; } = new();
    }
}
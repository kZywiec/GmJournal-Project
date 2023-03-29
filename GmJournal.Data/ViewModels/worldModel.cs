using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmJournal.Data.ViewModels
{
    public class worldModel : EntityBase
    {

        public worldModel() {}

        [StringLength(50)]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Enter date of next sesion")]
        [DataType(DataType.DateTime)]
        public DateTime NextSessionDate { get; set; }
    }
}

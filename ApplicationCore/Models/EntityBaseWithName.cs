using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models;
{
	public abstract class EntityBaseWithName
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(50)]
		[Display(Name = "Name")]
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }

		[HiddenInput]
		public DateTime CreationDate { get; set; }

		public EntityBaseWithName(string name)
		{
			this.Name = name;
			this.CreationDate = DateTime.Now;
		}
	}
}
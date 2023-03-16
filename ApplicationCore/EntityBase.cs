using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GmJournal.Data
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [HiddenInput]
        public DateTime CreationDate { get; set; }

        protected EntityBase()
            => CreationDate = DateTime.Now;
    }
}